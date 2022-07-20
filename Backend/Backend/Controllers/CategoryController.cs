using Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Mapper.Contracts;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryMapper _categoryMapper;

        public CategoryController(ICategoryService categoryService, ICategoryMapper categoryMapper)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }

        //get all categories
        [HttpGet]
        [Route("/categories")]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryDTO> categories = _categoryService.GetAll();
            return Ok(categories);
        }

        //get category by id
        [HttpGet]
        [Route("/categories/{id}")]
        public IActionResult GetById(int id)
        {
            Category category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                CategoryDTO categoryDTO = _categoryMapper.MapToDTO(category);
                return Ok(categoryDTO);
            }
        }

        //add category
        [HttpPost]
        [Route("/categories")]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            _categoryService.Add(categoryDTO);
            _categoryService.SaveCategory();
            return Ok(categoryDTO);
        }

        // update category
        [HttpPut]
        [Route("/categories/{id}")]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            Category category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _categoryService.Update(id, categoryDTO);
                _categoryService.SaveCategory();
                return Ok(categoryDTO);
            }
        }

        // delete category
        [HttpDelete]
        [Route("/categories/{id}")]
        public IActionResult Delete(int id)
        {
            Category category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _categoryService.Delete(id);
                _categoryService.SaveCategory();
                return Ok();
            }
        }
    }
}
