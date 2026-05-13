using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {

        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            var user=await _service.addUser(dto);
            if (user == null) return Conflict("Korisnik sa tim imenom vec postoji");
            return Ok(user);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
        {
            var token = await _service.login(dto);
            if (token == null) return Unauthorized("Pogresan email ili password");

            return Ok(new { token });
        }
    }
}
