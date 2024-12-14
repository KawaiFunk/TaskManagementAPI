using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskReturnDTO> CreateTask(TaskDTO taskDTO);
        Task<Models.Task> UpdateTask(TaskDTO taskDTO);
        Task<Models.Task> DeleteTask(Guid id);
        Task<Models.Task> GetTaskById(Guid id);
        Task<IEnumerable<Models.Task>> GetTasks();
    }
}
