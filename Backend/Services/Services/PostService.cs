using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationService _locationService;
        private readonly IPostMapper _postMapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, ISubCategoryService subCategoryService, ILocationRepository locationRepository, ILocationService locationService, IPostMapper postMapper, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._subCategoryService = subCategoryService;
            this._locationRepository = locationRepository;
            this._locationService = locationService;
            this._postMapper = postMapper;
            this.unitOfWork = unitOfWork;
        }
        public PagedResult<PostDTO> GetAll(int PageNumber, int PageSize, string SortBy = "", string SortDirection = "")
        {
            PagedResult<Post> posts = _postRepository.GetAll(PageNumber, PageSize, SortBy, SortDirection);

            PagedResult<PostDTO> postDTOs = new PagedResult<PostDTO>();
            foreach (var post in posts.Results)
            {
                PostDTO postDTO = _postMapper.MapToDTO(post);
                postDTOs.Results.Add(postDTO);
            }
            postDTOs.TotalRecords = posts.TotalRecords;

            return postDTOs;
        }
        public PostDTO GetById(int id)
        {
            Post post = _postRepository.GetById(id);
            PostDTO postDTO = _postMapper.MapToDTO(post);
            return postDTO;
        }
        public Post GetCategoryById(int id)
        {
            return _postRepository.GetById(id);
        }
        public PostDTO Add(PostDTO postDTO)
        {
            postDTO.CreatedAt = DateTime.UtcNow;
            Post post = _postMapper.MapFromDTO(postDTO);
            Post addedPost = _postRepository.Add(post);
            PostDTO result = _postMapper.MapToDTO(addedPost);
            return result;
        }
        public void Update(int id, PostDTO postDTO)
        {
            _postRepository.Update(id, _postMapper.MapFromDTO(postDTO));
        }
        public void Delete(int id)
        {
            Post post = _postRepository.GetById(id);
            _postRepository.Delete(post);
        }
        public bool PostExists(int id)
        {
            return _postRepository.IsExist(id);
        }
        public void SavePost()
        {
            unitOfWork.Commit();
        }
        public string Validate(PostDTO postDTO)
        {
            string error = "";
            if (!_locationService.LocationExists(postDTO.LocationId))
            {
                error = "Location is required";
            }
            if (!_subCategoryService.SubCategoryExists(postDTO.SubCategoryId))
            {
                error = "SubCategory is required";
            }

            return error;
        }

        public IEnumerable<PostDTO> GetAll(FilterDTO filterObject)
        {
            IEnumerable<Post> posts = _postRepository.GetAll(filterObject);
            List<PostDTO> postDTOs = new List<PostDTO>();
            foreach (var post in posts)
            {
                PostDTO postDTO = _postMapper.MapToDTO(post);
                postDTOs.Add(postDTO);
            }
            return postDTOs;
        }

        public IEnumerable<PostDTO> GetAll(string title)
        {
            IEnumerable<Post> posts = _postRepository.GetAll(title);
            List<PostDTO> postDTOs = new List<PostDTO>();
            foreach (var post in posts)
            {
                PostDTO postDTO = _postMapper.MapToDTO(post);
                postDTOs.Add(postDTO);
            }
            return postDTOs;
        }
    }
}
