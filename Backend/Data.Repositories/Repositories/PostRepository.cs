using Data.Infrastructure;
using Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Models.DTO;
using Models.Models;

namespace Data.Repositories.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Post> GetAll(FilterDTO filterObject)
        {
            IEnumerable<Post> postList= this.DbContext.Posts;
            if (filterObject.locationId!=null)
                postList= postList.Where(p => p.LocationId == filterObject.locationId);
            if(filterObject.subCategoryId!=null)
                postList = postList.Where(p => p.SubCategoryId == filterObject.subCategoryId);
            return postList;
        }

        public bool IsExist(int id)
        {
            return this.DbContext.Posts.Any(post => post.PostId == id);
        }
    }
}
