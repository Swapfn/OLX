using Data.Repositories.Contracts;
using Mapper.Contracts;
using Mapper.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Models;
using Services;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriesController : BaseController
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoriesController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // GET api/SubCategories/getByCategoryId/1
        [HttpGet]
        [Route("getByCategoryId/{id}")]
        public IActionResult GetAllByCategoryId(int id)
        {
            IEnumerable<SubCategoryDTO> result = _subCategoryService.GetAllByCategoryId(id);
            return Ok(result);
        }

        // GET api/SubCategories/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            SubCategoryDTO subCategoryDTO = _subCategoryService.GetById(id);
            return Ok(subCategoryDTO);

        }

        // POST api/Subcategories
        [HttpPost]
        [Route("")]
        public IActionResult Add(SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategoryDTO result = _subCategoryService.Add(subCategoryDTO);
            _subCategoryService.SaveSubCategory();
            return Ok(result);
        }


        // PUT api/Subcategories/1
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subCategoryDTO.SubCategoryID)
            {
                return BadRequest();
            }

            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            _subCategoryService.Update(id, subCategoryDTO);
            _subCategoryService.SaveSubCategory();
            SubCategoryDTO result = _subCategoryService.GetById(id);

            return Ok(result);
        }

        // DELETE api/subcategories/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            if (!_subCategoryService.SubCategoryExists(id))
            {
                return NotFound();
            }

            _subCategoryService.Delete(id);
            _subCategoryService.SaveSubCategory();
            return Ok("SubCategory deleted");

        }
    }
}
