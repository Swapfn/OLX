using Models.DTO;
using Models.Models;


namespace Mapper.Contracts
{
    public interface IUserMapper
    {
        ApplicationUser Map(UserDTO userDTO);
        UserDTO Map(ApplicationUser user);
    }
}
