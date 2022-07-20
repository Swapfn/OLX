using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;

namespace WepAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAccountService _account;
        private readonly ITokenService _token;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IAccountService account, ITokenService token)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _account = account;
            _token = token;

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            return await _account.LoginAsync(model, _userManager, _roleManager, _token);

        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO model)
        {
            return await _account.RegisterAsync(model, _userManager);

        }

        [HttpPost]
        [Route("passwordchange")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model)
        {
            return await _account.ChangePasswordAsync(model, _userManager, _roleManager, _token);

        }
    }
}
