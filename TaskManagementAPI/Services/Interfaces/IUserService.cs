using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(UserDTO userDTO);
    }
}
