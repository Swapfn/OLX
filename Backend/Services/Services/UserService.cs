using Microsoft.AspNetCore.Identity;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services.Services
{
    public class UserService : IUserService
    {
        /// <summary>
        /// Returns userDTO from token
        /// </summary>
        /// <param name="identity"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public async Task<ApplicationUser> GetUserByIdAsync(ClaimsIdentity identity, 
            UserManager<ApplicationUser> userManager)
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
                return user;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Edit user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<ApplicationUser> UpdateUserAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager,
            UserDTO model)
        {
            var user = await GetUserByIdAsync(identity, userManager);
            //userManager.
            return null;
        }

        public async Task DeleteUserAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager)
        {
            var user = await GetUserByIdAsync(identity, userManager);
            userManager.DeleteAsync(user);
            // what http to send here ??
        }
    }
}
