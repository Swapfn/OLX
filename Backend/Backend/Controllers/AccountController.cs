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
        private readonly IRegisterService _reg;
        private readonly ITokenService _token;
        private readonly ILoginService _login;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IRegisterService reg, ITokenService token, ILoginService login)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _reg = reg;
            _token = token;
            _login = login;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            return await _login.Login(model, _userManager, _roleManager, _token);

        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            return await _reg.RegisterAsync(model, _userManager);

        }
    }
}
