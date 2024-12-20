using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskReturnDTO> CreateTask(TaskDTO taskDTO);
        Task<Models.Task> UpdateTask(TaskUpdateDTO taskDTO);
        Task<Models.Task> DeleteTask(Guid id);
        Task<TaskReturnDTO> GetTaskById(Guid id);
        Task<IEnumerable<Models.Task>> GetTasks();
        Task<TaskReturnDTO> AssignCategory(Guid taskId, string categoryName);
        Task<TaskReturnDTO> MarkAsCompleted(Guid id);
    }
}
