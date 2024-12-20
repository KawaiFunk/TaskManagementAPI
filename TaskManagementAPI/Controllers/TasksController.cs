using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Authorize]
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateTask(TaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest("Invalid task data.");
            }

            try
            {
                var createdTask = await _taskService.CreateTask(taskDTO);
                return Ok(new { message = "Task created succesfully", task = createdTask });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating task", error = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                var deletedTask = await _taskService.DeleteTask(id);
                return Ok(new { message = "Task deleted succesfully", task = deletedTask });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting task", error = ex.Message });
            }
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetUserTasks()
        {
            try
            {
                var tasks = await _taskService.GetTasks();
                return Ok(new {message = "Tasks retrieved succesfully", tasks = tasks});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving tasks", error = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateTask(TaskUpdateDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest("Invalid task data.");
            }
            try
            {
                var updatedTask = await _taskService.UpdateTask(taskDTO);
                return Ok(new { message = "Task updated succesfully", task = updatedTask });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating task", error = ex.Message });
            }
        }

        [HttpGet("GetTask/{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            try
            {
                var task = await _taskService.GetTaskById(id);
                return Ok(new { message = "Task retrieved succesfully", task = task });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving task", error = ex.Message });
            }
        }

        [HttpPost("AssignCategory")]
        public async Task<IActionResult> AssignCategory(Guid id, string categoryName)
        {
            try
            {
                var updatedTask = await _taskService.AssignCategory(id, categoryName);
                return Ok(new { message = "Category assigned succefully", task = updatedTask});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Category asssignment failed", error = ex.Message});
            }
        }

        [HttpPost("MarkAsCompleted")]
        public async Task<IActionResult> MarkAsCompleted(Guid id)
        {
            try
            {
                var updatedTask = await _taskService.MarkAsCompleted(id);
                return Ok(new { message = "Task marked as completed", task = updatedTask });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error marking task as completed", error = ex.Message });
            }
        }
    }
}
