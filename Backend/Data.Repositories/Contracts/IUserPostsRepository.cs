using Models.Models;

namespace Data.Repositories.Contracts
{
    public interface IUserPostsRepository
    {
        public ICollection<Post> GetAllPosts();
    }
}
