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

        [HttpGet("all")]
        public IActionResult GetTasks()
        {
            return Ok(new { Message = "This is secired" });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin/all")]
        public IActionResult AdminGet()
        {
            return Ok(new { Message = "This is an admin endpoint" });
        }

        [HttpPost("Create")]
        [Authorize]
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
    }
}
