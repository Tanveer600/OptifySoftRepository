using Application.OptifySoft.DTO;
using Application.OptifySoft.Interface;
using Application.OptifySoft.Services;
using Domain.OptifySoft.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptifySoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly Permissionservice _permissionservice;
        public PermissionController(Permissionservice permissionservice)
        {
            _permissionservice = permissionservice;
        }
        // GET: api/v1/permission
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _permissionservice.GetPermissionsAsync(cancellationToken);
            return Ok(result);
        }

        // GET: api/v1/permission/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _permissionservice.GetPermissionByIdAsync(id, cancellationToken);
            if (result == null || result.Data == null)
                return NotFound(new { Message = $"permission with ID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/permission
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Permission dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _permissionservice.CreatePermissionAsync(dto, cancellationToken);

            if (!result.Success)
                return BadRequest(result);

            // Return 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Data.PermissionId }, result);
        }

        // PUT: api/v1/permission/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Permission dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _permissionservice.UpdatePermissionAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"permission with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/permission/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _permissionservice.DeletePermissionAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"permission with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
