    using TaskManagementAPI.Data;
    using TaskManagementAPI.Models;
    using TaskManagementAPI.Models.DTOs;
    using TaskManagementAPI.Repositories.IRepositories;
    using Task = TaskManagementAPI.Models.Task;

    namespace TaskManagementAPI.Repositories
    {
        public class UserRepository : IUserRepository
        {
            private readonly TasksContext _context;

            public UserRepository(TasksContext context)
            {
                _context = context;
            }

            public async Task<User> CreateUser(UserDTO userDTO)
            {
                var user = new User
                {
                    UserName = userDTO.UserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password),
                    Email = userDTO.Email,
                    Role = "User",
                    Tasks = null
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }

            public Task<User> DeleteUser(int id)
            {
                throw new NotImplementedException();
            }

            public Task<User> GetUserById(int id)
            {
                throw new NotImplementedException();
            }

            public Task<IEnumerable<User>> GetUsers()
            {
                throw new NotImplementedException();
            }

            public Task<User> UpdateUser(User user)
            {
                throw new NotImplementedException();
            }
        }
    }
