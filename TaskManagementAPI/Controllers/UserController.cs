using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                var createdUser = await _userService.CreateUser(userDTO);
                return Ok(new { message = "User created successfully", user = createdUser });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error creating user", error = ex.Message });
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Invalid user data");
            }

            try
            {
                var updatedUser = await _userService.UpdateUser(userDTO);
                return Ok(new { message = "User updated succesfully", user = updatedUser });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = "Error updating user", error = ex.Message});
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(id);
                if (deletedUser == null)
                {
                    return NotFound(new { message = "User not found" });
                }
                return Ok(new { message = "User deleted successfully", user = deletedUser });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error deleting user", error = ex.Message });
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                if(user == null)
                {
                    return NotFound(new { message = "User not found"});
                }
                return Ok(new { message = "User found succesfully", user = user});
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error finding user", error = ex.Message});
            }
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                if (users == null)
                {
                    return NotFound(new { message = "Users not found" });
                }
                return Ok(new { message = "Users found succesfully", user = users });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "Error finding users", error = ex.Message });
            }
        }
    }
}
