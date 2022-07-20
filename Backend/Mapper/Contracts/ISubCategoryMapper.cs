using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface ISubCategoryMapper
    {
        SubCategory Map(SubCategoryDTO categoryDTO);
        SubCategoryDTO Map(SubCategory category);
    }
}
