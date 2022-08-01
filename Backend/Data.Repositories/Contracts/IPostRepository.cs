using Data.Infrastructure;
using Models.DTO;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        public Post GetById(int id);
        PagedResult<Post> GetAll(int PageNumber, int PageSize, string SortBy = "", string SortDirection = "");
        bool IsExist(int id);
        IEnumerable<Post> GetAll(FilterDTO filterObject);
    }
}
