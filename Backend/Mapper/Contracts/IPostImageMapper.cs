using Models.DTO;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper.Contracts
{
    public interface IPostImageMapper
    {
        PostImage MapFromDTO(PostImageDTO postimageDTO);
        PostImageDTO MapToDTO(PostImage postimage);
    }
}
