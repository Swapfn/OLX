using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class SubCategoryMapper : ISubCategoryMapper
    {
        public SubCategory Map(SubCategoryDTO categoryDTO)
        {
            SubCategory subCategory = new SubCategory();
            subCategory.SubCategoryID = categoryDTO.SubCategoryID;
            subCategory.SubCategoryName = categoryDTO.SubCategoryName;
            return subCategory;
        }

        public SubCategoryDTO Map(SubCategory subCategory)
        {
            SubCategoryDTO subCategoryDTO = new SubCategoryDTO();
            subCategoryDTO.CategoryID = subCategory.CategoryID;
            subCategoryDTO.CategoryName = subCategory.Category?.CategoryName;
            subCategoryDTO.SubCategoryID = subCategory.SubCategoryID;
            subCategoryDTO.SubCategoryName = subCategory.SubCategoryName;
            return subCategoryDTO;
        }
    }
}
