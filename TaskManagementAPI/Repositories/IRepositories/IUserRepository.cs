using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        //Get all users
        Task<IEnumerable<User>> GetUsers();
        //Get user by ID
        Task<User> GetUserById(int id);
        //Create user
        Task<User> CreateUser(UserDTO userDTO);
        //Update user
        Task<User> UpdateUser(User user);
        //Delete user
        Task<User> DeleteUser(int id);
    }
}
