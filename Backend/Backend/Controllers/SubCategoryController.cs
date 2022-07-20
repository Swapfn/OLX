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
    public class SubCategoryController : BaseController
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        // get subcategory list of category by id
        [HttpGet]
        [Route("/subcategories/getByCategoryId/{id}")]
        public IActionResult GetAllByCategoryId(int id)
        {
            IEnumerable<SubCategoryDTO> result = _subCategoryService.GetAllByCategoryId(id);
            return Ok(result);
        }

        // get subcategory by id
        [HttpGet]
        [Route("/subcategories/{id}")]
        public IActionResult GetById(int id)
        {
            SubCategory subCategory = _subCategoryService.GetSubCategoryById(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            else
            {
                SubCategoryDTO result = _subCategoryService.GetById(id);
                return Ok(result);
            }
        }

        // add subcategory
        [HttpPost]
        [Route("/subcategories")]
        public IActionResult Add(SubCategoryDTO subCategoryDTO)
        {
            SubCategoryDTO result = _subCategoryService.Add(subCategoryDTO);
            _subCategoryService.SaveSubCategory();
            return Ok(result);
        }


        // update subcategory
        [HttpPut]
        [Route("/subcategories/{id}")]
        public IActionResult Update(int id, SubCategoryDTO subCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubCategory subCategory = _subCategoryService.GetSubCategoryById(id);
            if (subCategory == null)
            {
                return NotFound();
            }

            try
            {
                _subCategoryService.Update(id, subCategoryDTO);
                _subCategoryService.SaveSubCategory();
                return Ok(subCategoryDTO);
            }
            catch
            {
                throw;
            }


        }

        // delete subcategory
        [HttpDelete]
        [Route("/subcategories/{id}")]
        public IActionResult DeleteSubCategory(int id)
        {
            SubCategory subCategory = _subCategoryService.GetSubCategoryById(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            else
            {
                _subCategoryService.Delete(id);
                _subCategoryService.SaveSubCategory();
                return Ok();
            }
        }
    }
}
