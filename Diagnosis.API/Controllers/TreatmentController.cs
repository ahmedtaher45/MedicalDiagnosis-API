using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.UseCases;
using Diagnosis.Application.UseCases.Treatment;
using Diagnosis.Application.UseCases.TreatmentManagement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentController : ControllerBase
    {
        private readonly GetPatientTreatmentInfoUseCase _getPatientInfoUseCase;
        private readonly CreateTreatmentPlanUseCase _createTreatmentPlanUseCase;
        private readonly CreatePrescriptionUseCase _createPrescriptionUseCase;
        private readonly GetTreatmentPlanDetailsUseCase _getTreatmentPlanDetailsUseCase;
        private readonly GenerateTreatmentPlanPdfUseCase _generatePdfUseCase;


        public TreatmentController(
            GetPatientTreatmentInfoUseCase getPatientInfoUseCase,
            CreateTreatmentPlanUseCase createTreatmentPlanUseCase,
            CreatePrescriptionUseCase createPrescriptionUseCase,
            GetTreatmentPlanDetailsUseCase getTreatmentPlanDetailsUseCase,
            GenerateTreatmentPlanPdfUseCase generatePdfUseCase)
        {
            _getPatientInfoUseCase = getPatientInfoUseCase;
            _createTreatmentPlanUseCase = createTreatmentPlanUseCase;
            _createPrescriptionUseCase = createPrescriptionUseCase;
            _getTreatmentPlanDetailsUseCase = getTreatmentPlanDetailsUseCase;
            _generatePdfUseCase = generatePdfUseCase;
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
        public async Task<IActionResult> GetPatientTreatmentInfo(string patientId)
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
        public async Task<IActionResult> CreateTreatmentPlan(
            [FromBody] CreateTreatmentPlanDto dto)
        {
            try
            {
                var result = await _createTreatmentPlanUseCase.ExecuteAsync(dto);
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
        [HttpPost("prescription")]
        public async Task<IActionResult> CreatePrescription(
            [FromBody] CreatePrescriptionDto dto)
        {
            try
            {
                var result = await _createPrescriptionUseCase.ExecuteAsync(dto);
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
        [HttpGet("treatment-plan/{treatmentPlanId}")]
        public async Task<IActionResult> GetTreatmentPlanDetails(string treatmentPlanId)
        {
            try
            {
                var result = await _getTreatmentPlanDetailsUseCase.ExecuteAsync(treatmentPlanId);
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
        [HttpGet("treatment-plan/{treatmentPlanId}/pdf")]
        public async Task<IActionResult> DownloadTreatmentPlanPdf(string treatmentPlanId)
        {
            try
            {
                var pdfBytes = await _generatePdfUseCase.ExecuteAsync(treatmentPlanId);
                return File(pdfBytes, "application/pdf", $"TreatmentPlan_{treatmentPlanId}.pdf");
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