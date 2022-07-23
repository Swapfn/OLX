using Models.DTO;
using Models.Models;

namespace Services
{
    public interface IPostService
    {
        IEnumerable<PostDTO> GetAll();
        PostDTO GetById(int id);
        PostDTO Add(PostDTO postDTO);
        void Update(int id, PostDTO postDTO);
        void Delete(int id);
        bool PostExists(int id);
        void SavePost();
        string Validate(PostDTO postDTO);
        IEnumerable<PostDTO> GetAll(FilterDTO filterObject);
    }
}
