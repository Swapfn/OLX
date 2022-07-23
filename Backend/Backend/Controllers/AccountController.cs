using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Models.DTO;
using Models.Models;
using Services;
using System.Security.Claims;

namespace WepAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAccountService _account;
        private readonly ITokenService _token;
        private readonly IUserMapper _mapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IAccountService account, ITokenService token, IUserMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _account = account;
            _token = token;
            _mapper = mapper;

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
