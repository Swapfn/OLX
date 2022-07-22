﻿using Mapper.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IPostMapper _postMapper;

        public PostsController(IPostService postService, IPostMapper postMapper)
        {
            _postService = postService;
            _postMapper = postMapper;
        }

        // GET api/Posts
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<PostDTO> postDTO = _postService.GetAll();
            return Ok(postDTO);
        }

        // GET api/Posts/1
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

        // POST api/Posts
        [HttpPost]
        [Route("")]
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

            PostDTO result = _postService.Add(postDTO);
            _postService.SavePost();
            return Ok(result);
        }

        // PUT api/Posts/1
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

        // DELETE api/Posts/1
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
    }
}
