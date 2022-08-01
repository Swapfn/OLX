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
                                        .Include(post => post.PostImages)
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
                                        .Include(post => post.PostImages)
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
                                        .Include(post => post.PostImages)
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
                                        .Include(post => post.PostImages)
                                        .Include(l => l.Location)
                                        .Include(s => s.SubCategory)
                                        .OrderByDescending(on => on.CreatedAt)
                                        .Skip((PageNumber - 1) * PageSize)
                                        .Take(PageSize)
                                        .ToList();
                }
            }

            posts.TotalRecords = posts.Results.Count();
            return posts;
        }

        public PagedResult<Post> GetAll(FilterDTO<PostDTO> FilterObject)
        {
            PagedResult<Post> posts = new PagedResult<Post>();
            Expression<Func<Post, bool>> SearchCriteria = a => (
            (a.Title.Contains(FilterObject.SearchObject.Title) || string.IsNullOrEmpty(FilterObject.SearchObject.Title))
            &&
            (a.Description.Contains(FilterObject.SearchObject.Description) || string.IsNullOrEmpty(FilterObject.SearchObject.Description))
            &&
            (a.SubCategoryId == FilterObject.SearchObject.SubCategoryId || FilterObject.SearchObject.SubCategoryId == 0)
            &&
            (a.LocationId == FilterObject.SearchObject.LocationId || FilterObject.SearchObject.LocationId == 0)
            &&
            (a.SubCategory.CategoryID == FilterObject.SearchObject.CategoryId || FilterObject.SearchObject.CategoryId == 0)
            &&
            (a.Price >= FilterObject.SearchObject.minPrice || FilterObject.SearchObject.minPrice == 0)
            &&
            (a.Price <= FilterObject.SearchObject.maxPrice || FilterObject.SearchObject.maxPrice == 0)
            );
            posts = this.GetAll(FilterObject.PageNumber, FilterObject.PageSize, FilterObject.Includes, SearchCriteria, FilterObject.SortBy, FilterObject.SortDirection);
            return posts;
        }

        private PagedResult<Post> GetAll(
            int PageNumber,
            int PageSize,
            List<string> includes,
            Expression<Func<Post, bool>> filter = null,
            string SortBy = "",
            string SortDirection = ""
            )
        {
            PagedResult<Post> PagedList = new PagedResult<Post>();
            IQueryable<Post> Query = this.DbContext.Posts.AsQueryable<Post>();
            foreach (string include in includes)
            {
                Query = Query.Include(include).Where(p => p.IsAvailable);
            }
            string SortByParam = "CreationDate";
            string SortDirectionParam = "ASC";

            if (!string.IsNullOrEmpty(SortBy))
            {
                SortByParam = SortBy;
            }
            if (!string.IsNullOrEmpty(SortDirection))
            {
                SortDirectionParam = SortDirection;
            }
            if (filter != null)
            {
                Query = Query.Where(filter);
            }

            PagedList.TotalRecords = Query.AsNoTracking().ToList().Count();

            if (SortDirectionParam.ToLower() == "asc")
            {
                Query = Query.OrderBy(SortByParam);
            }
            else
            {
                Query = Query.OrderByDescending(SortByParam);
            }


            Query = Query.Skip((PageNumber - 1) * PageSize);

            PagedList.Results = Query.Take(PageSize).AsNoTracking().ToList();
            return PagedList;
        }

        public bool IsExist(int id)
        {
            return this.DbContext.Posts.Any(post => post.PostId == id);
        }
    }
}

