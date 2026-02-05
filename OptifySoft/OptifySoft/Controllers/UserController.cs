using Application.OptifySoft.DTO.UserDto;
using Application.OptifySoft.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace OptifySoft.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET ALL USERS
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _userService.GetUsersAsync(cancellationToken);
            return Ok(result);
        }

        // GET USER BY ID
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserByIdAsync(id, cancellationToken);

            if (result == null || result.Data == null)
                return NotFound(new { Message = $"User with ID {id} not found" });

            return Ok(result);
        }

        // CREATE USER
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto,CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUserAsync(dto, cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Data },
                result
            );
        }


        // UPDATE USER
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.UpdateUserAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"User with ID {id} not found" });

            return Ok(result);
        }

        // DELETE USER
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUserAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"User with ID {id} not found" });

            return NoContent();
        }

        [HttpPost("login")]
        [AllowAnonymous] // No token required
        public async Task<IActionResult> Login([FromBody] LoginUserDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginUser(dto, cancellationToken);

            if (result == null || result.Data == null)
                return Unauthorized(new { Message = "Invalid credentials" });

            return Ok(result); // Returns user info + token
        }

    }
}
