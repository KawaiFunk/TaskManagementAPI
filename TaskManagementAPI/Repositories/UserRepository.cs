using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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

            public async Task<User> DeleteUser(Guid id)
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return null;
                }
                
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }

            public async Task<User> GetUserById(Guid id)
            {
                var user = await _context.Users.FindAsync(id);
                if(user == null)
                {
                    return null;
                }

                return user;
            }

            public async Task<IEnumerable<User>> GetUsers()
            {
                var users = await _context.Users.ToListAsync();
                if(users == null)
                {
                    return null;
                }

                return users;
            }

            public async Task<User> UpdateUser(UpdateUserDTO userDTO)
            {
                var user = await _context.Users.FindAsync(userDTO.ID);
                if (user == null) 
                { 
                    return null;
                }

                if (!string.IsNullOrEmpty(userDTO.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                }

                user.UserName = userDTO.UserName;
                user.Email = userDTO.Email;
                user.Role = userDTO.Role;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
        }
    }
