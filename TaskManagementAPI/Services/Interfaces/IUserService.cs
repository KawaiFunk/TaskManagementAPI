using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserReturnDTO> CreateUser(UserDTO userDTO);
        Task<UserReturnDTO> UpdateUser(UpdateUserDTO userDTO);
        Task<UserReturnDTO> DeleteUser(Guid id);
        Task<UserReturnDTO> GetUserById(Guid id);
        Task<IEnumerable<UserReturnDTO>> GetUsers();
    }
}
