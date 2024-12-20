using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;

namespace TaskManagementAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TasksContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TaskRepository(TasksContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Models.Task> CreateTask(TaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                throw new Exception("Task data missing");
            }

            var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Claim 'NameIdentifier' is missing from the token.");
            }

            if (!Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                throw new UnauthorizedAccessException($"Claim 'NameIdentifier' value '{userIdClaim.Value}' is not a valid GUID.");
            }

            var user = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.ID == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var task = new Models.Task
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                DueDate = taskDTO.DueDate,
                Status = taskDTO.Status,
                Priority = taskDTO.Priority,
                UserId = userId,
                User = user,
                Category = null,
                CategoryId = null
            };

            user.Tasks.Add(task);

            // Add task to Tasks DbSet
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<User> GetUserWithTasks(Guid userId)
        {
            var user = await _context.Users
                .Include(u => u.Tasks)
                .FirstOrDefaultAsync(u => u.ID == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public async Task<Models.Task> DeleteTask(Guid id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.ID == id);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<Models.Task> GetTaskById(Guid id)
        {
            var task = await _context.Tasks.Include(t => t.User).Include(t => t.Category).FirstOrDefaultAsync(t => t.ID == id);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            return task;
        }

        public async Task<IEnumerable<Models.Task>> GetTasks()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }

            var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var tasks = await _context.Tasks.Where(t => t.UserId == Guid.Parse(userIdClaim.Value)).ToListAsync();

            return tasks;
        }

        public async Task<Models.Task> UpdateTask(TaskUpdateDTO taskDTO)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == taskDTO.ID);

            if (task == null)
            {
                throw new Exception("Task not found");
            }

            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.DueDate = taskDTO.DueDate;
            task.Status = taskDTO.Status;
            task.Priority = taskDTO.Priority;

            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Models.Task> AssignCategory(Guid taskId, string categoryName)
        {
            var task = await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.ID == taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            var category = await _context.Categories.Include(t => t.Tasks).FirstOrDefaultAsync(c => c.Name == categoryName);
            if (category == null)
            {
                throw new Exception("Category not found");
            }

            task.Category = category;
            task.CategoryId = category.ID;

            await _context.SaveChangesAsync();

            return task;
        }
    }
}
