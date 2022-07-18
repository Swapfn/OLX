using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Services
{
    public class LoginService : ControllerBase, ILoginService
    {

        public async Task<IActionResult> Login(LoginDTO model, UserManager<ApplicationUser> userManager,
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
    }
}
