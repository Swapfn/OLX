using Data.Infrastructure;
using Models.DTO;
using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IPostRepository : IRepository<Post>
    {
        public Post GetById(int id);
        PagedResult<Post> GetAll(int PageNumber, int PageSize, string SortBy = "", string SortDirection = "");
        IEnumerable<Post> GetAll(FilterDTO filterObject);
        bool IsExist(int id);

        /// <summary>
        /// Get user posts by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<Post> GetAvailablePostsByUser(int id);

    }
}
