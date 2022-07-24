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
