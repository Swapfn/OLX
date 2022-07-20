
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;

namespace Services
{
    public interface IAccountService
    {
        public Task<IActionResult> RegisterAsync(RegisterDTO model, UserManager<ApplicationUser> userManager);

        public Task<IActionResult> LoginAsync(LoginDTO model, UserManager<ApplicationUser> usermanager,
            RoleManager<ApplicationRole> rolemanager, ITokenService token);

        public Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model, UserManager<ApplicationUser> usermanager,
            RoleManager<ApplicationRole> rolemanager, ITokenService token);

    }
}
