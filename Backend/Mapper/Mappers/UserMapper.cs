

using Mapper.Contracts;
using Models.DTO;
using Models.Models;

namespace Mapper.Mappers
{
    public class UserMapper : IUserMapper
    {
        public ApplicationUser Map(UserDTO userDTO)
        {
            ApplicationUser user = new();
            user.UserName = userDTO.UserName;
            user.FName = userDTO.FirstName;
            user.LName = userDTO.LastName;
            user.Email = userDTO.Email;
            return user;
        }

        public UserDTO Map(ApplicationUser user)
        {
            UserDTO userDTO = new();
            userDTO.UserName = user.UserName;
            userDTO.FirstName = user.FName;
            userDTO.LastName = user.LName;
            userDTO.Email = user.Email;
            return userDTO;
        }
    }
}
