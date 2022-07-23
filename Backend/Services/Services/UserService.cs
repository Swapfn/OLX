using Mapper.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services.Services
{
    public class UserService : ControllerBase, IUserService
    {
        /// <summary>
        /// Returns userDTO from token
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        async Task<IActionResult> IUserService.GetUserByIdAsync(ClaimsIdentity identity, 
            UserManager<ApplicationUser> userManager, IUserMapper mapper)
        {
            int userId = 0;

            // if claims exists
            if (identity != null)
            {
                // get user nameid claim
                userId = int.Parse(identity.Claims.First(x => x.Type.Contains("nameidentifier")).Value);
            }

            // find user by id
            var user = await userManager.FindByIdAsync(userId.ToString());

            // map the user if exists
            if (user != null)
            {
                // fix to return user only and return userDTO in controller
                var userDTO = mapper.Map(user);
                return Ok(userDTO);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
