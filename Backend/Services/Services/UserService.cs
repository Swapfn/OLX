using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            //user.UserName = user.UserName;
            user.AboutMe = model.AboutMe;
            user.PhoneNumber = model.Phone;
            user.FName = model.FirstName;
            user.LName = model.LastName;
            user.NormalizedEmail = model.Email.ToUpper();
            user.Email = model.Email;


            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<StatusCodeResult> DeleteUserAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager)
        {
            var user = await GetUserByIdAsync(identity, userManager);
            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return new StatusCodeResult(204);
            }
            else
            {
                return new StatusCodeResult(400);
            }
        }
    }
}
