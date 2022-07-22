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
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IPostMapper _postMapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, ISubCategoryRepository subCategoryRepository, IPostMapper postMapper, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._subCategoryRepository = subCategoryRepository;
            this._postMapper = postMapper;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<PostDTO> GetAll()
        {
            IEnumerable<Post> posts = _postRepository.GetAll();

            List<PostDTO> postDTOs = new List<PostDTO>();
            foreach (var post in posts)
            {
                PostDTO postDTO = _postMapper.MapToDTO(post);
                postDTOs.Add(postDTO);
            }
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
            if (postDTO.Title == null)
            {
                error += "Title is required";
            }
            if (postDTO.Description == null)
            {
                error += "Description  is required";
            }
            return error;
        }
    }
}
