using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface ICategoryMapper
    {
        Category Map(CategoryDTO categoryDTO);
        CategoryDTO Map(Category category);
    }
}
