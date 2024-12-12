using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        //Get all users (Done)
        Task<IEnumerable<User>> GetUsers();
        //Get user by ID (Done)
        Task<User> GetUserById(Guid id);
        //Create user (Done)
        Task<User> CreateUser(UserDTO userDTO);
        //Update user (Done)
        Task<User> UpdateUser(UpdateUserDTO userDTO);
        //Delete user (Done)
        Task<User> DeleteUser(Guid id);
    }
}
