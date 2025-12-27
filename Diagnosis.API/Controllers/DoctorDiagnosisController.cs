using Diagnosis.Application.DTOs.DoctorDiagnosis;
using Diagnosis.Application.UseCases.DoctorDiagnosis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorDiagnosisController : ControllerBase
    {
        [Authorize(Roles = "Doctor")]
        [HttpGet("templates")]
        public async Task<IActionResult> GetAllTemplates(
            [FromServices] GetAllTemplatesUseCase getAllTemplatesUseCase)
        {
            var result = await getAllTemplatesUseCase.ExecuteAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("template/{templateId}")]
        public async Task<IActionResult> GetTemplate(
            [FromRoute] int templateId,
            [FromServices] GetTemplateUseCase getTemplateUseCase
            )
        {
            var result = await getTemplateUseCase.ExecuteAsync(templateId);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("analyze")]
        public async Task<IActionResult> AnalyzeDiagnosis(
            [FromBody] GetDoctorDiagnosisDTO getDoctorDiagnosisDTO,
            [FromServices] GetDoctorDiagnosisUseCase getDoctorDiagnosisUseCase
            )
        {
            var result = await getDoctorDiagnosisUseCase.ExecuteAsync(getDoctorDiagnosisDTO);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
