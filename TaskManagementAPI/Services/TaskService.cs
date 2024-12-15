﻿using TaskManagementAPI.Models.DTOs;
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
                UserName = createdTask.User.UserName
            };
            return taskReturnDTO;
        }

        public Task<Models.Task> DeleteTask(Guid id)
        {
            var deletedTask = _taskRepository.DeleteTask(id);
            return deletedTask;
        }

        public Task<Models.Task> GetTaskById(Guid id)
        {
            throw new NotImplementedException();
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
