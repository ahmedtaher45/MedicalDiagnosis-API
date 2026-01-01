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

        [HttpPut("ai/rate-limit")]
        public async Task<IActionResult> DefineMaxAiRequest(
            [FromBody] MaxRequestDTO maxRequestDTO,
            [FromServices] DefineMaxAiRequestUseCase maxAiRequestUseCase
            )
        {
            var result = await maxAiRequestUseCase.ExecuteAsync(maxRequestDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("doctor/rate-limit")]
        public async Task<IActionResult> DefineMaxDoctorDiagnosis(
            [FromBody] MaxRequestDTO maxRequestDTO,
            [FromServices] DefineMaxDoctorDiagnosisUseCase maxDoctorDiagnosisUseCase
            )
        {
            var result = await maxDoctorDiagnosisUseCase.ExecuteAsync(maxRequestDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("ai/toggle")]
        public async Task<IActionResult> ToggleAi(
            [FromBody] EnableAiDTO enableAiDTO,
            [FromServices] ToggleAiUseCase toggleAiUseCase
            )
        {
            var result = await toggleAiUseCase.ExecuteAsync(enableAiDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }
}
