using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{

    public class UserController : APIBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IUserMapper _mapper;
        private readonly IUserService _user;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IUserService user, IUserMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _user = user;

        }

        [Authorize]
        [HttpGet]
        [Route("getuser")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            return await _user.GetUserByIdAsync(identity, _userManager, _mapper);
        }
    }
}
