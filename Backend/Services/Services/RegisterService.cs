
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class RegisterService : ControllerBase, IRegisterService
    {
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
    }
}
