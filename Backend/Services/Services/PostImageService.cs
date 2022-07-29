using Data.Infrastructure;
using Data.Repositories.Contracts;
using Mapper.Contracts;
using Models.DTO;
using Models.Models;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PostImageService : IPostImageService
    {
        private readonly IPostImageRepository _postimageRepository;
        private readonly IPostImageMapper _postimageMapper;
        private readonly IUnitOfWork _unitOfWork;

        public PostImageService(IPostImageRepository postimageRepository, IPostImageMapper postimageMapper, IUnitOfWork unitOfWork)
        {
            _postimageRepository = postimageRepository;
            _postimageMapper = postimageMapper;
            _unitOfWork = unitOfWork;
        }
        public PostImageDTO Add(PostImageDTO postimageDTO)
        {
            var postimage = _postimageMapper.MapFromDTO(postimageDTO);
            PostImage addedPostImage = _postimageRepository.Add(postimage);
            PostImageDTO result = _postimageMapper.MapToDTO(addedPostImage);
            return result;
        }

        public void Delete(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            _postimageRepository.Delete(postimage);
        }

        public IEnumerable<PostImageDTO> GetAll()//all images of all posts
        {
            IEnumerable<PostImage> postimages = _postimageRepository.GetAll();
            IEnumerable<PostImageDTO> postimagesDTO = postimages.Select(postimage => _postimageMapper.MapToDTO(postimage));
            return postimagesDTO;
        }

        public PostImageDTO GetById(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            PostImageDTO postimageDTO = _postimageMapper.MapToDTO(postimage);
            return postimageDTO;
        }

        public void Update(int id, PostImageDTO postimageDTO)
        {
            PostImage postimage = _postimageMapper.MapFromDTO(postimageDTO);
            _postimageRepository.Update(id, postimage);
        }
        public bool ImageExists(int id)
        {
            PostImage postimage = _postimageRepository.GetById(id);
            return postimage != null;
        }
        public void SavePostImage()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<PostImageDTO> GetAll(int id)
        {
            IEnumerable<PostImage> postimages = _postimageRepository.GetAll(id);
            IEnumerable<PostImageDTO> postimagesDTO = postimages.Select(postimage => _postimageMapper.MapToDTO(postimage));
            return postimagesDTO;
        }
    }
}
