using Application.OptifySoft.Interface;
using Application.OptifySoft.Services;
using Domain.OptifySoft.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptifySoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleservice;
        public RoleController(IRoleService roleService)
        {
           _roleservice = roleService; 
        }
        // GET: api/v1/Role
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _roleservice.GetRolesAsync(cancellationToken);
            return Ok(result);
        }

        // GET: api/v1/Role/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _roleservice.GetRoleByIdAsync(id, cancellationToken);
            if (result == null || result.Data == null)
                return NotFound(new { Message = $"Role with ID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/Role
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleservice.CreateRoleAsync(dto, cancellationToken);

            if (!result.Success)
                return BadRequest(result);

            // Return 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Data.RoleId }, result);
        }

        // PUT: api/v1/Role/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Role dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _roleservice.UpdateRoleAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"permission with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/Role/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _roleservice.DeleteRoleAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"Role with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
