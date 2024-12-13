using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDTO userDTO);
        Task<string> Login(string username, string password);
    }
}
