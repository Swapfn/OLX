﻿using Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;

namespace WepAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("api/categories")]
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categoryService.GetAll();
        }
        [HttpGet]
        [Route("api/categories/{id}")]
        public CategoryDTO GetById(int id)
        {
            return _categoryService.GetById(id);
        }
        [HttpPost]
        [Route("api/categories")]
        public IActionResult Add([FromBody] CategoryDTO categoryDTO)
        {
            _categoryService.Add(categoryDTO);
            _categoryService.SaveCategory();
            return Ok(categoryDTO);
        }
        [HttpPut]
        [Route("api/categories/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CategoryDTO categoryDTO)
        {
            _categoryService.Update(id, categoryDTO);
            _categoryService.SaveCategory();
            return Ok(categoryDTO);
        }
        [HttpDelete]
        [Route("api/categories/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _categoryService.Delete(id);
            _categoryService.SaveCategory();
            return Ok();
        }
    }
}
