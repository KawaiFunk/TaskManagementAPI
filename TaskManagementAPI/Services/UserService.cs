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

        public async Task<UserReturnDTO> CreateUser(UserDTO userDTO)
        {
            var user = await _userRepository.CreateUser(userDTO);
            return ConvertToDTO(user);
        }

        public async Task<UserReturnDTO> UpdateUser(UpdateUserDTO userDTO)
        {
            var user = await _userRepository.UpdateUser(userDTO);
            return ConvertToDTO(user);
        }

        public async Task<UserReturnDTO> DeleteUser(Guid id)
        {
            var user = await _userRepository.DeleteUser(id);
            return ConvertToDTO(user);
        }

        public async Task<UserReturnDTO> GetUserById(Guid id)
        {
            var user = await _userRepository.GetUserById(id);
            return ConvertToDTO(user);
        }

        public async Task<IEnumerable<UserReturnDTO>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            var userDtos = users.Select(user => new UserReturnDTO
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role,
            }).ToList();

            return userDtos;
        }

        private UserReturnDTO ConvertToDTO(User user)
        {
            return new UserReturnDTO
            {
                ID = user.ID,
                UserName = user.UserName,
                Email = user.Email,
                Role = user.Role,
                Tasks = user.Tasks?.Select(task => new TaskReturnDTO
                {
                    ID = task.ID,
                    Title = task.Title,
                    Description = task.Description,
                    DueDate = task.DueDate,
                    Status = task.Status,
                    Priority = task.Priority,
                }).ToList()
            };
        }

    }
}
