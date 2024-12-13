using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models.DTOs;
using TaskManagementAPI.Services.Interfaces;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                var registeredUser = await _authService.Register(userDTO);
                return Ok(new { message = "User registered successfully", user = registeredUser });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error registering user", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Invalid credentials.");
            }

            try
            {
                var token = _authService.Login(username, password);
                return Ok(new { message = "Login successful", token.Result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error logging in", error = ex.Message });
            }
        }
    }
}
