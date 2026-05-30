using Microsoft.AspNetCore.Mvc;
using TaskApp.DTOs;
using TaskApp.Services.IServices;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO dto)
        {
            var result = _authService.Register(dto);

            if (result == null)
             return BadRequest("Email already exists");

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO dto)
        {
            var result = _authService.Login(dto);

            if (result.UserId == 0)
                return Unauthorized(result);

            return Ok(result);
        }
    }
}