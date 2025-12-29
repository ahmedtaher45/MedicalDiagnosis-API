using Diagnosis.Application.DTOs.SupportTicket;
using Diagnosis.Application.UseCases.SupportTicket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SupportTicketController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateSupportTicketAsync([FromBody]SupportTicketDTO supportTicketDTO, [FromServices]AddSupportTicketUseCase supportTicketUseCase)
        {

            if (supportTicketDTO == null)
                return BadRequest("SupportTicketDTO cannot be null.");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            await supportTicketUseCase.CreateSupportTicketAsync(userId , supportTicketDTO);

            return Ok(new { Message = "Support ticket created successfully." });

        }
        [HttpGet]
        public async Task<ActionResult<List<GetSupportTicketDTO>>> GetSupportTicketsAsync([FromServices]GetSupportTicketsUseCase getSupportTicketsUseCase)
        {
            
            var tickets = await getSupportTicketsUseCase.GetSupportTicketsAsync();
            return Ok(tickets);
        }
    }
}
