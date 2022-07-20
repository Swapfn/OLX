using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    public class AccountService : ControllerBase, IAccountService
    {

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public async Task<IActionResult> RegisterAsync(RegisterDTO model, UserManager<ApplicationUser> userManager)
        {
            // check if user exists
            var userCheck = await userManager.FindByNameAsync(model.Username);
            if (userCheck != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO() 
                { Status = "Error", Message = "User Already Exists" });
            }

            // create user
            ApplicationUser user = new()
            {
                UserName = model.Username,
                Email = model.Email,
                // snapshot of current user credientials, if they change, security stamp will change
                SecurityStamp = Guid.NewGuid().ToString(),
                FName = model.FName,
                LName = model.LName
                
            };

            // bind user and role
            var resultUser = await userManager.CreateAsync(user, model.Password);
            var resultRole = await userManager.AddToRoleAsync(user, "User");

            // if fail
            if (!resultRole.Succeeded && !resultUser.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO()
                { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            }

            // if succeeded
            return Ok(new ResponseDTO { Status = "Success", Message = "User created successfully!" });
        }



        /// <summary>
        /// Login
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="_token"></param>
        /// <returns></returns>
        public async Task<IActionResult> LoginAsync(LoginDTO model, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, ITokenService _token)
        {
            // get user and roles
            var user = await userManager.FindByNameAsync(model.Username);
            var roles = await userManager.GetRolesAsync(user);

            // check if user exists
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var token = await _token.CreateToken(user, roles, roleManager);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }


        /// <summary>
        /// Password Change
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userManager"></param>
        /// <param name="roleManager"></param>
        /// <param name="_token"></param>
        /// <returns></returns>
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, ITokenService _token)
        {
            // get user and roles
            var user = await userManager.FindByNameAsync(model.Username);
            var roles = await userManager.GetRolesAsync(user);

            // check if user exists
            if (user != null && await userManager.CheckPasswordAsync(user, model.CurrentPassword))
            {
                // change password
                if (model.NewPassword == model.ConfirmNewPassword)
                {
                    await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                }
                var token = await _token.CreateToken(user, roles, roleManager);

                return Ok(new
                {
                    message = "Password Changed Successfuly",
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }
    }
}
