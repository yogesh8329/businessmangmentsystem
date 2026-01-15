using BMS.Core.DTOs;
using BMS.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly IUserRepository _userRepository;

            public UsersController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var users = await _userRepository.GetAllAsync();
                return Ok(users);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null) return NotFound();
                return Ok(user);
            }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto dto)
        {
            if (dto == null)
                return BadRequest("User data is required");

            var newUserId = await _userRepository.AddAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newUserId },
                new { id = newUserId }
            );
        }

    }
}
