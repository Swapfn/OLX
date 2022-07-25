using Data.Infrastructure;
using Data.Repositories.Contracts;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class UserPostsRepository : BaseRepository<UserPosts>, IUserPostsRepository
    {
        public UserPostsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public ICollection<Post> GetAllPosts()
        {
            return null;
        }
    }
}
