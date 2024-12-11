using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(UserDTO userDTO)
        {
            var user = await _userRepository.CreateUser(userDTO);
            return user;
        }
    }
}
