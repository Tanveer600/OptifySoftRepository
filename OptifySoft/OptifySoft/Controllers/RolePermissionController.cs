using Application.OptifySoft.Interface;
using Domain.OptifySoft.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptifySoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _rolePermissionService;
        public RolePermissionController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService= rolePermissionService;
        }
        // GET: api/v1/RolePermission
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _rolePermissionService.GetRolePermissionsAsync(cancellationToken);
            return Ok(result);
        }

        // GET: api/v1/RolePermission/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _rolePermissionService.GetRolePermissionByIdAsync(id, cancellationToken);
            if (result == null || result.Data == null)
                return NotFound(new { Message = $"RolePermission with ID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/RolePermission
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolePermission dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rolePermissionService.CreateRolePermissionAsync(dto, cancellationToken);

            if (!result.Success)
                return BadRequest(result);

            // Return 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Data.RoleId }, result);
        }

        // PUT: api/v1/RolePermission/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] RolePermission dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _rolePermissionService.UpdateRolePermissionAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"rolepermission with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/RolePermission/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _rolePermissionService.DeleteRolePermissionAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"RolePermission with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
