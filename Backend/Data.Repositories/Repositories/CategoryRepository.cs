using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
