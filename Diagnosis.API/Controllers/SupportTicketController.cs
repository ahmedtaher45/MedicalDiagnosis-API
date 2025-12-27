using Diagnosis.Application.DTOs.SupportTicket;
using Diagnosis.Application.UseCases.SupportTicket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateSupportTicketAsync([FromBody]SupportTicketDTO supportTicketDTO , [FromServices]AddSupportTicketUseCase supportTicketUseCase)
        {
            if (supportTicketDTO == null)
                return BadRequest("SupportTicketDTO cannot be null.");

            await supportTicketUseCase.CreateSupportTicketAsync(supportTicketDTO);

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
