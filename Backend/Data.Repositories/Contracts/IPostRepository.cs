using Data.Infrastructure;
using Models.DTO;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        bool IsExist(int id);
        IEnumerable<Post> GetAll(FilterDTO filterObject);
    }
}
