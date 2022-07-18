﻿using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class CategoryMapper : ICategoryMapper
    {
        public Category Map(CategoryDTO categoryDTO)
        {
            Category category = new Category();
            category.CategoryID = categoryDTO.CategoryID;
            category.CategoryName = categoryDTO.CategoryName;
            return category;
        }

        public CategoryDTO Map(Category category)
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.CategoryID = category.CategoryID;
            categoryDTO.CategoryName = category.CategoryName;
            return categoryDTO;
        }
    }
}