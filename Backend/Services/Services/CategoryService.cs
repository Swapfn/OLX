using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ICategoryMapper _categoryMapper;
        private readonly ISubCategoryMapper _subCategoryMapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper, ISubCategoryRepository subCategoryRepository, ISubCategoryMapper subCategoryMapper, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._subCategoryRepository = subCategoryRepository;
            this._categoryMapper = categoryMapper;
            this._subCategoryMapper = subCategoryMapper;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryDTO> GetAll()
        {
            IEnumerable<Category> categories = _categoryRepository.GetAllCategories();

            List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

            foreach (var category in categories)
            {
                CategoryDTO categoryDTO = _categoryMapper.MapToDTO(category);
                List<SubCategoryDTO> subCategories = category.SubCategories.Select(subCategory => _subCategoryMapper.MapToDTO(subCategory)).ToList();
                categoryDTO.SubCategories = subCategories;
                categoryDTOs.Add(categoryDTO);
            }
            return categoryDTOs;
        }
        public CategoryDTO GetById(int id)
        {
            return _categoryMapper.MapToDTO(_categoryRepository.GetById(id));
        }
        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }
        public CategoryDTO Add(CategoryDTO categoryDTO)
        {
            return _categoryMapper.MapToDTO(_categoryRepository.Add(_categoryMapper.MapFromDTO(categoryDTO)));
        }
        public void Update(int id, CategoryDTO categoryDTO)
        {
            _categoryRepository.Update(id, _categoryMapper.MapFromDTO(categoryDTO));
        }
        public void Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            IEnumerable<SubCategory> subCategories = _subCategoryRepository.GetAllByCategoryId(id);
            foreach (var subCategory in subCategories)
            {
                _subCategoryRepository.Delete(subCategory);
            }
            _categoryRepository.Delete(category);
        }
        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
