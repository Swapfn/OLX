using Data.Infrastructure;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        bool IsExist(int id);
    }
}
