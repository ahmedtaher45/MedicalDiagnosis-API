using Diagnosis.Application.DTOs;
using Diagnosis.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        [Authorize("Patient")]
        [HttpPost("ai-plan{InquiryId}")]
        public async Task<IActionResult> CreateAITreatment(
            [FromRoute] int InquiryId,
            [FromServices] CreateAITreatmentUseCase createAITreatmentUseCase)
        {
            var result = await createAITreatmentUseCase.ExecuteAsync(InquiryId);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

    }

}
