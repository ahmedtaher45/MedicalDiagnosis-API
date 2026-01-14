using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.UseCases;
using Diagnosis.Application.UseCases.Treatment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly GetPatientTreatmentInfoUseCase _getPatientInfoUseCase;
       // private readonly CreateTreatmentPlanUseCase _createTreatmentPlanUseCase;
        private readonly CreatePrescriptionUseCase _createPrescriptionUseCase;
      // private readonly GetTreatmentPlanDetailsUseCase _getTreatmentPlanDetailsUseCase;


        public TreatmentController(
            GetPatientTreatmentInfoUseCase getPatientInfoUseCase,
           // CreateTreatmentPlanUseCase createTreatmentPlanUseCase,
            CreatePrescriptionUseCase createPrescriptionUseCase)
           // GetTreatmentPlanDetailsUseCase getTreatmentPlanDetailsUseCase)
        {
            _getPatientInfoUseCase = getPatientInfoUseCase;
           // _createTreatmentPlanUseCase = createTreatmentPlanUseCase;
            _createPrescriptionUseCase = createPrescriptionUseCase;
           // _getTreatmentPlanDetailsUseCase = getTreatmentPlanDetailsUseCase;
        }

        [Authorize("Patient")]
        [HttpGet("ai-plan/{DiagnosisId}")]
        public async Task<IActionResult> CreateAITreatment(
            [FromRoute] int DiagnosisId,
            [FromServices] CreateAITreatmentUseCase createAITreatmentUseCase)
        {
            var result = await createAITreatmentUseCase.ExecuteAsync(DiagnosisId);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetPatientTreatmentInfo(int patientId)
        {
            try
            {
                var result = await _getPatientInfoUseCase.ExecuteAsync(patientId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("treatment-plan")]
        //public async Task<IActionResult> CreateTreatmentPlan(
        //    [FromBody] TreatmentPlanDetailsDto dto)
        //{
            //try
            //{
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            //    //var result = await _createTreatmentPlanUseCase.ExecuteAsync(dto,userId);
            //    return Ok(result);
            //}
            //catch (KeyNotFoundException ex)
            //{
            //    return NotFound(new { message = ex.Message });
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(new { message = ex.Message });
            //}
        //}

        [Authorize(Roles = "Doctor")]
        [HttpPost("prescription")]
        public async Task<IActionResult> CreatePrescription(
            [FromBody] CreatePrescriptionDto dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
                var result = await _createPrescriptionUseCase.ExecuteAsync(dto, userId);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}