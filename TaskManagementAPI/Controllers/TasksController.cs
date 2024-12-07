using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    [Authorize]
    public class TasksController : Controller
    {
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
    }
}
