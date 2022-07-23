using Mapper.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using System.Security.Claims;

namespace Services.Contracts
{
    public interface IUserService
    {
        public Task<IActionResult> GetUserByIdAsync(ClaimsIdentity identity, UserManager<ApplicationUser> userManager,
            IUserMapper mapper);
    }
}
