using Mapper.Contracts;
using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Mappers
{
    public class PostImageMapper : IPostImageMapper
    {
        public PostImage MapFromDTO(PostImageDTO postimageDTO)
        {
            PostImage postimage = new PostImage();
            postimage.PostImageID = postimageDTO.PostImageID;
            postimage.ImageURL = postimageDTO.ImageURL;
            postimage.PostId = postimageDTO.PostId;
            return postimage;
        }

        public PostImageDTO MapToDTO(PostImage postimage)
        {
            PostImageDTO postimageDTO = new PostImageDTO();
            postimageDTO.PostImageID = postimage.PostImageID;
            postimageDTO.ImageURL = postimage.ImageURL;
            postimageDTO.PostId = postimage.PostId;
            return postimageDTO;
        }
    }
}
