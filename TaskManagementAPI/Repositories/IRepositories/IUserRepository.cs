using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(Guid id);
        Task<User> CreateUser(UserDTO userDTO);
        Task<User> UpdateUser(UpdateUserDTO userDTO);
        Task<User> DeleteUser(Guid id);
    }
}
