using Models.DTO;

namespace Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        CategoryDTO GetById(int id);
        CategoryDTO Add(CategoryDTO categoryDTO);
        void Update(int id, CategoryDTO categoryDTO);
        void Delete(int id);
        void SaveCategory();
    }
}
