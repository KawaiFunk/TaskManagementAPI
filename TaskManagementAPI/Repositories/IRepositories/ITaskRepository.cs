﻿using TaskManagementAPI.Models.DTOs;

namespace TaskManagementAPI.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        Task<Models.Task> CreateTask(TaskDTO taskDTO);
        Task<Models.Task> UpdateTask(TaskDTO taskDTO);
        Task<Models.Task> DeleteTask(Guid id);
        Task<Models.Task> GetTaskById(Guid id);
        Task<IEnumerable<Models.Task>> GetTasks();
    }
}
