
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;

namespace Services
{
    public interface IRegisterService
    {
        public Task<IActionResult> RegisterAsync(RegisterDTO model, UserManager<ApplicationUser> userManager);

    }
}
