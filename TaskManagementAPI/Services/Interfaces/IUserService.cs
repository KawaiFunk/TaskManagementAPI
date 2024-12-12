using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDTO userDTO);
        Task<User> UpdateUser(UpdateUserDTO userDTO);
        Task<User> DeleteUser(Guid id);
        Task<User> GetUserById(Guid id);
        Task<IEnumerable<User>> GetUsers();
    }
}
