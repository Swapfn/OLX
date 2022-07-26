using Models.DTO;
using Models.Models;

namespace Mapper.Contracts
{
    public interface IPostMapper
    {
        Post MapFromDTO(PostDTO postDTO);
        PostDTO MapToDTO(Post post);
    }
}
