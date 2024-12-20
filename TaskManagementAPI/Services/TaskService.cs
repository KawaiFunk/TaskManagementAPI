using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Repositories.IRepositories;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<TaskReturnDTO> AssignCategory(Guid taskId, string categoryName)
        {
            var task = await _taskRepository.AssignCategory(taskId, categoryName);
            var taskDTO = new TaskReturnDTO
            {
                ID = task.ID,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                Title = task.Title,
                UserName = task.User.UserName,
                CateogryName = task.Category.Name
            };

            return taskDTO;
        }

        public async Task<TaskReturnDTO> CreateTask(TaskDTO taskDTO)
        {
            var createdTask = await _taskRepository.CreateTask(taskDTO);
            TaskReturnDTO taskReturnDTO = new TaskReturnDTO
            {
                ID = createdTask.ID,
                Title = createdTask.Title,
                Description = createdTask.Description,
                DueDate = createdTask.DueDate,
                Priority = createdTask.Priority,
                Status = createdTask.Status,
                UserName = createdTask.User.UserName,
                CateogryName = null
            };
            return taskReturnDTO;
        }

        public Task<Models.Task> DeleteTask(Guid id)
        {
            var deletedTask = _taskRepository.DeleteTask(id);
            return deletedTask;
        }

        public async Task<TaskReturnDTO> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            var returnTask = new TaskReturnDTO
            {
                ID = task.ID,
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                Status = task.Status,
                UserName = task.User.UserName,
                CateogryName = task.Category.Name
            };

            return returnTask;
        }

        public async Task<IEnumerable<Models.Task>> GetTasks()
        {
            var tasks = await _taskRepository.GetTasks();
            return tasks;
        }

        public async Task<Models.Task> UpdateTask(TaskUpdateDTO taskDTO)
        {
            var updatedTask = await _taskRepository.UpdateTask(taskDTO);
            return updatedTask;
        }
    }
}
