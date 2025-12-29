using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.UseCases.Inquiry;
using Diagnosis.Application.UseCases.PatientDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Patient")]
    public class InquiryController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddInquiry(
            [FromServices] AddInquiryUseCase addInquiryUseCase,
            [FromForm] AddInquiryDTO addInquiryDTO)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var result = await addInquiryUseCase.ExecuteAsync(addInquiryDTO, userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    

        [HttpGet("inquiries")]
        public async Task<IActionResult> GetInquiries(
        [FromServices] GetInquiriesUseCase getInquiriesUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var result = await getInquiriesUseCase.ExecuteAsync(userId);
            return Ok(result);
        }

        [HttpGet("{inquiryId}")]
        public async Task<IActionResult> GetInquiry(
            [FromRoute] int inquiryId,
            [FromServices] GetInquiryUseCase getInquiryUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();

            var result = await getInquiryUseCase.ExecuteAsync(userId, inquiryId);
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
