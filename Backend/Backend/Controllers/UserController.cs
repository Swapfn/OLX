using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
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
            IUserService user,IUserMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _user = user;

        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUserDataAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _user.GetUserByIdAsync(identity, _userManager);
            if (user != null)
            {
                var userDTO = _mapper.MapToDTO(user);
                return Ok(userDTO);
            } else
            {
                return NotFound();    
            }
        }


        [Authorize]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateUserDataAsync(UserDTO model)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var user = await _user.UpdateUserAsync(identity, _userManager, model);
            if (user != null)
            {
                var userDTO = _mapper.MapToDTO(user);
                return Ok(new { userDTO, message="User Update Successfuly"});
            }
            else
            {
                return NotFound();
            }
        }


        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUserDataAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var result = await _user.DeleteUserAsync(identity, _userManager);
            if (result.StatusCode == 204)
            {
                return Ok(new {Message = "Deleted Successfuly"});
            }
            else
            {
                return NotFound();
            }
        }
    }
}
