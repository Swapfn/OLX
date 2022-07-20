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
        private readonly ICategoryMapper _categoryMapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryMapper categoryMapper, IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._categoryMapper = categoryMapper;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<CategoryDTO> GetAll()
        {
            return _categoryRepository.GetAll().Select(category => _categoryMapper.Map(category));
        }
        public CategoryDTO GetById(int id)
        {
            return _categoryMapper.Map(_categoryRepository.GetById(id));
        }
        public CategoryDTO Add(CategoryDTO categoryDTO)
        {
            return _categoryMapper.Map(_categoryRepository.Add(_categoryMapper.Map(categoryDTO)));
        }
        public void Update(int id, CategoryDTO categoryDTO)
        {
            _categoryRepository.Update(id, _categoryMapper.Map(categoryDTO));
        }
        public void Delete(int id)
        {
            Category category = _categoryRepository.GetById(id);
            _categoryRepository.Delete(category);
        }
        public void SaveCategory()
        {
            unitOfWork.Commit();
        }
    }
}
