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
   
    public class SupportTicketController : ControllerBase
    {
        [Authorize]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateSupportTicketAsync([FromBody]SupportTicketDTO supportTicketDTO, [FromServices]AddSupportTicketUseCase supportTicketUseCase)
        {

            if (supportTicketDTO == null)
                return BadRequest("SupportTicketDTO cannot be null.");
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            await supportTicketUseCase.CreateSupportTicketAsync(userId , supportTicketDTO);

            return Ok(new { Message = "Support ticket created successfully." });

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("SupportTicket")]
        public async Task<ActionResult<List<GetSupportTicketDTO>>> GetSupportTicketsAsync([FromServices]GetSupportTicketsUseCase getSupportTicketsUseCase)
        {
            
            var tickets = await getSupportTicketsUseCase.GetSupportTicketsAsync();
            return Ok(tickets);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Reply")]
        public async Task<IActionResult> AddSupportTicketReplyAsync([FromBody]SupportTicketReplyDTO supportTicketReplyDTO , [FromServices]AddSuportTicketReplyUseCase addSuportTicketReplyUseCase)
        {
            await addSuportTicketReplyUseCase.AddSupportTicketReplyAsync(supportTicketReplyDTO);
            return Ok("Reply added Successfully");
        }
        [Authorize]
        [HttpGet("Reply")]
        public async Task<IActionResult> GetLatestReplyByUserAsync([FromServices]GetSuportTicketReplyUseCase getSuportTicketReplyUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var reply = await getSuportTicketReplyUseCase.GetLatestReplyByUserAsync(userId);

            if (reply == null)
                return NotFound("No reply found for this user.");

            return Ok(reply);
        }
    }
}
