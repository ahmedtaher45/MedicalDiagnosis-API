using Diagnosis.Application.DTOs.SystemSettings;
using Diagnosis.Application.UseCases.SystemSittings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SystemSettingsController : ControllerBase
    {
        [HttpPost("add-admin")]
        public async Task<IActionResult> AddAdmin(
            [FromBody] AddAdminDTO addAdminDTO,
            [FromServices] AddAdminUseCase addAdminUseCase
            )
        {
            var result = await addAdminUseCase.ExecuteAsync(addAdminDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
