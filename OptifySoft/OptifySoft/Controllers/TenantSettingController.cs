using Application.OptifySoft.Services;
using Domain.OptifySoft.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OptifySoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantSettingController : ControllerBase
    {
        private readonly TenantSettingService _tenantsettingservice;
        public TenantSettingController(TenantSettingService tenantsettingservice)
        {
            _tenantsettingservice = tenantsettingservice;
        }
        // GET: api/v1/TenantSetting
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await _tenantsettingservice.GetTenantSettingsAsync(cancellationToken);
            return Ok(result);
        }

        // GET: api/v1/TenantSetting/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _tenantsettingservice.GetTenantSettingByIdAsync(id, cancellationToken);
            if (result == null || result.Data == null)
                return NotFound(new { Message = $"TenantSetting with ID {id} not found" });

            return Ok(result);
        }

        // POST: api/v1/TenantSetting
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TenantSetting dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tenantsettingservice.CreateTenantSettingAsync(dto, cancellationToken);

            if (!result.Success)
                return BadRequest(result);

            // Return 201 Created with Location header
            return CreatedAtAction(nameof(GetById), new { id = result.Data.TenantId }, result);
        }

        // PUT: api/v1/TenantSetting/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TenantSetting dto, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tenantsettingservice.UpdateTenantSettingAsync(id, dto, cancellationToken);

            if (result == null || !result.Success)
                return NotFound(new { Message = $"TenantSetting with ID {id} not found" });

            return Ok(result);
        }

        // DELETE: api/v1/TenantSetting/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _tenantsettingservice.DeleteTenantSettingAsync(id, cancellationToken);

            if (result == null || !result.Data)
                return NotFound(new { Message = $"TenantSetting with ID {id} not found" });

            // Return 204 No Content
            return NoContent();
        }
    }
}
