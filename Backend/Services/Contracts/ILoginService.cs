
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;

namespace Services
{
    public interface ILoginService
    {
        public Task<IActionResult> Login(LoginDTO model, UserManager<ApplicationUser> usermanager,
            RoleManager<ApplicationRole> rolemanager, ITokenService token);
    }
}
