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
            IEnumerable<Post> postList = this.DbContext.Posts;

            if (filterObject.locationId != null)
                postList = postList.Where(p => p.LocationId == filterObject.locationId);
            if (filterObject.subCategoryId != null)
                postList = postList.Where(p => p.SubCategoryId == filterObject.subCategoryId);
            if (filterObject.maxPrice != null)
                postList = postList.Where(p => p.Price <= filterObject.maxPrice);
            if (filterObject.minPrice != null)
                postList = postList.Where(p => p.Price >= filterObject.minPrice);
            /*if (filterObject.categoryId != null)
                postList = postList.Where(p => p.SubCategory.CategoryID >= filterObject.categoryId);*/

            return postList;
        }

        public Post GetById(int id) => this.DbContext.Posts.Include(p => p.User).Include(l => l.Location).Include(s => s.SubCategory).FirstOrDefault(p => p.PostId == id);

        public PagedResult<Post> GetAll(int PageNumber, int PageSize, string SortBy = "CreatedAt", string SortDirection = "")
        {
            PagedResult<Post> posts = new PagedResult<Post>();
            if (SortBy.ToLower().Equals("price"))
            {
                if (SortDirection.ToLower().Equals("asc"))
                {
                    posts.Results = this.DbContext.Posts
                                        .Include(p => p.User)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderBy(on => on.Price)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
                else
                {
                    posts.Results = this.DbContext.Posts
                                        .Include(p => p.User)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderByDescending(on => on.Price)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }

            }
            else
            {
                if (SortDirection.ToLower().Equals("asc"))
                {
                    posts.Results = this.DbContext.Posts
                                        .Include(p => p.User)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderBy(on => on.CreatedAt)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
                else
                {
                    posts.Results = this.DbContext.Posts
                                        .Include(p => p.User)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderByDescending(on => on.CreatedAt)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
            }

            posts.TotalRecords = this.DbContext.Posts.Count();
            return posts;
        }

        public bool IsExist(int id)
        {
            return this.DbContext.Posts.Any(post => post.PostId == id);
        }
    }
}
