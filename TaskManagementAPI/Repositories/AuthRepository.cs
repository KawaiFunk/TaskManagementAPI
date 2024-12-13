using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;

namespace TaskManagementAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TasksContext _context;

        public AuthRepository(TasksContext context)
        {
            _context = context;
        }

        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(UserDTO userDTO)
        {
            var user = new User
            {
                ID = Guid.NewGuid(),
                UserName = userDTO.UserName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = "User",
                Tasks = null
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
