using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.UseCases.DiagnosisModule;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DiagnosisModuleController : ControllerBase
    {
        [Authorize(Roles = "Patient")]
        [HttpPost("create-daignosis")]
        public async Task<IActionResult> CreateDiagnosis(
            [FromServices] CreateDiagnosisUseCase createDiagnosisUseCase,
            [FromBody] CreateDiagnosisDTO createDiagnosisDTO)
        {
            var result = await createDiagnosisUseCase.ExecuteAsync(createDiagnosisDTO);

            if (!result.Success)
            {
                return BadRequest(new {result.Success, result.Message});
            }
            return Ok(result);
        }
    }
}
