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

            var user = await _context.Users.FindAsync(userId);

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

            await _context.Tasks.AddAsync(task);
            _context.SaveChanges();
            return task;
        }

        public Task<Models.Task> DeleteTask(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task> GetTaskById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Task>> GetTasks()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task> UpdateTask(TaskDTO taskDTO)
        {
            throw new NotImplementedException();
        }
    }
}
