using Mapper.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;
using Services.Contracts;
using System.Security.Claims;

namespace WepAPI.Controllers
{
    [Authorize]
    public class PostsController : APIBaseController
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;

        public PostsController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
        }

        // GET Posts
        //[Authorize]
        //[HttpGet]
        //[Route("{PageNumber}/{PageSize}/{SortBy}/{SortDirection}")]
        //public IActionResult GetAll(int PageNumber, int PageSize, string SortBy, string SortDirection)
        //{
        //    PagedResult<PostDTO> postDTO = _postService.GetAll(PageNumber, PageSize, SortBy, SortDirection);
        //    return Ok(postDTO);
        //}

        // GET Posts/1
        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_postService.PostExists(id))
            {
                return NotFound();
            }

            PostDTO postDTO = _postService.GetById(id);
            return Ok(postDTO);
        }

        // POST Posts
        [Authorize]
        [HttpPost]
        [Route("add")]
        public IActionResult Add(PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string ErrorMessage = _postService.Validate(postDTO);
            if (ErrorMessage != "")
            {
                return NotFound(ErrorMessage);
            }

            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            Task<ApplicationUser> user = _userService.GetUserByIdAsync(identity);
            postDTO.UserID = user.Result.Id;

            PostDTO result = _postService.Add(postDTO);
            _postService.SavePost();
            return Ok(result);
        }

        // PUT Posts/1
        [Authorize]
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, PostDTO postDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != postDTO.PostId)
            {
                return BadRequest();
            }

            if (!_postService.PostExists(id))
            {
                return NotFound();
            }

            _postService.Update(id, postDTO);
            _postService.SavePost();
            PostDTO result = _postService.GetById(id);
            return Ok(result);
        }

        // DELETE Posts/1
        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_postService.PostExists(id))
            {
                return NotFound();
            }

            _postService.Delete(id);
            _postService.SavePost();
            return Ok("Post deleted");
        }
        [HttpPost]
        [Route("")]
        public IActionResult GetAll(FilterDTO<PostDTO> filterObject)
        {
            PagedResult<PostDTO> postDTO = _postService.GetAll(filterObject);
            //if no search is applied
            if (filterObject.SearchObject == null)
            {
                filterObject.SearchObject = new PostDTO();
            }
            return Ok(postDTO);
        }
    }
}
