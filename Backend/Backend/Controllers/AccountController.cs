using Microsoft.AspNetCore.Http;
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
        private readonly IConfiguration _configuration;
        private IRegisterService _reg;
        private ITokenService _token;
        private ILoginService _login;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration, IRegisterService reg, ITokenService token, ILoginService login)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
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
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            return await _reg.RegisterAsync(model, _userManager);

        }
    }
}
