using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;
using System.Security.Claims;

namespace WepAPI.Controllers
{
    public class AccountController : APIBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        private readonly IUserMapper _userMapper;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IAccountService accountService,
            ITokenService tokenService,
            IUserMapper userMapper
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
            _tokenService = tokenService;
            _userMapper = userMapper;

        }

        // POST login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO model)
        {
            return await _accountService.LoginAsync(model, _userManager, _roleManager, _tokenService);

        }

        // POST register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDTO model)
        {
            return await _accountService.RegisterAsync(model, _userManager);

        }

        // POST changePassword
        [HttpPost]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordDTO model)
        {
            return await _accountService.ChangePasswordAsync(model, _userManager, _roleManager, _tokenService);

        }

    }
}
