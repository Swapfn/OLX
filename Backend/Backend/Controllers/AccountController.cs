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

        // GET getUser
        // 1 refer to admin role
        [Authorize(Roles = "1")]
        [HttpGet]
        [Route("getUser")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            int userId = 0;
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                userId = int.Parse(identity.Claims.First(x => x.Type.Contains("nameidentifier")).Value);
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var userDTO = _userMapper.MapToDTO(user);
                return Ok(userDTO);
            }
            else
            {
                return Unauthorized();
            }

            //var tokenService = Request.Headers[HeaderNames.Authorization];

            //int id = _tokenService.VerifyToken(tokenService);

        }
    }
}
