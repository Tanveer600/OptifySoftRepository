using Application.OptifySoft.DTO;
using Application.OptifySoft.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace OptifySoft.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        // GET: api/v1/menu
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _menuService.GetMenusAsync(cancellationToken);
            return Ok(result);
        }

        // GET: api/v1/menu/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _menuService.GetMenuByIdAsync(id, cancellationToken);
            if (result == null || result.Data == null)
                return NotFound(new { Message = $"Menu with ID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/menu
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MenuDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _menuService.CreateMenuAsync(dto, cancellationToken);

            if (!result.Success)
                return BadRequest(result);

            // Return 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        // PUT: api/v1/menu/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMenuDto dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _menuService.UpdateMenuAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"Menu with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/menu/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _menuService.DeleteMenuAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"Menu with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
