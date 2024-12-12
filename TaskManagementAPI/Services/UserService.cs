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

        public async Task<User> UpdateUser(UpdateUserDTO userDTO)
        {
            var user = await _userRepository.UpdateUser(userDTO);
            return user;
        }

        public async Task<User> DeleteUser(Guid id)
        {
            var user = await _userRepository.DeleteUser(id);
            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return users;
        }
    }
}
