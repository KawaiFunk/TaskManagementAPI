using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<string> Login(string username, string password)
        {
            return _authRepository.Login(username, password);
        }

        public Task<User> Register(UserDTO userDTO)
        {
            return _authRepository.Register(userDTO);
        }
    }
}
