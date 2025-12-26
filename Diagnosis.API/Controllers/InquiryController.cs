using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.UseCases.Inquiry;
using Diagnosis.Application.UseCases.PatientDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Patient")]
    public class InquiryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddInquiry(
            [FromServices] AddInquiryUseCase addInquiryUseCase,
            [FromForm] AddInquiryDTO addInquiryDTO)
        {
            var result = await addInquiryUseCase.ExecuteAsync(addInquiryDTO);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    

        [HttpGet("inquiries/{patientId}")]
        public async Task<IActionResult> GetInquiries(
        [FromRoute] int patientId,
        [FromServices] GetInquiriesUseCase getInquiriesUseCase)
        {
            var result = await getInquiriesUseCase.ExecuteAsync(patientId);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetInquiry(
            [FromQuery] int patientId,
            [FromQuery] int inquiryId,
            [FromServices] GetInquiryUseCase getInquiryUseCase)
        {
            var result = await getInquiryUseCase.ExecuteAsync(patientId, inquiryId);
            return Ok(result);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("recent/{patientId}")]
        public async Task<IActionResult> GetRecentInquiries(
            [FromRoute] int patientId,
            [FromServices] GetRecentInquiriesUseCase getRecentInquiriesUseCase)
        {
            var result = await getRecentInquiriesUseCase.GetRecentInquiries(patientId);
            return Ok(result);
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("pending/{patientId}")]
        public async Task<IActionResult> GetPendingInquiriesCount(
            [FromRoute] int patientId,
            [FromServices] GetPendingInquiriesCountUseCase getPendingInquiriesCountUseCase)
        {
            var result = await getPendingInquiriesCountUseCase.ExecuteAsync(patientId);
            return Ok(result);
        }
    }
}
