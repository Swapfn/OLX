using Mapper.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using System.Security.Claims;

namespace Services.Contracts
{
    public interface IUserService
    {
        public Task<ApplicationUser> GetUserByIdAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager);
        public Task<ApplicationUser> UpdateUserAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager,
            UserDTO model);
        public Task DeleteUserAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager);
    }
}
