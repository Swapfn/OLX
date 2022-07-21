using Services;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Mapper.Contracts;
using Data.Repositories.Contracts;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryMapper _categoryMapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryService categoryService, ICategoryMapper categoryMapper, ICategoryRepository categoryRepository)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
            _categoryRepository = categoryRepository;
        }

        // GET api/Categories
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            IEnumerable<CategoryDTO> categoriesDTO = _categoryService.GetAll();
            return Ok(categoriesDTO);
        }

        // GET api/Categories/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            CategoryDTO categoryDTO = _categoryService.GetById(id);
            return Ok(categoryDTO);
        }

        // POST api/Categories
        [HttpPost]
        [Route("")]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _categoryService.Add(categoryDTO);
            _categoryService.SaveCategory();
            return Ok(categoryDTO);
        }

        // PUT api/Categories/1
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoryDTO.CategoryID)
            {
                return BadRequest();
            }

            if (!CategoryExists(id))
            {
                return NotFound();
            }

            _categoryService.Update(id, categoryDTO);
            _categoryService.SaveCategory();
            CategoryDTO result = _categoryService.GetById(id);
            return Ok(result);
        }

        // DELETE api/Categories/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }

            _categoryService.Delete(id);
            _categoryService.SaveCategory();
            return Ok();
        }

        private bool CategoryExists(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category != null;
        }
    }
}
