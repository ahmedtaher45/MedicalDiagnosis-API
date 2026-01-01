using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.WebUtilities;
using Diagnosis.Application.DTOs.Consultation;
using Diagnosis.Application.UseCases.Consultation;
using Diagnosis.Application.UseCases.PatientDashboard;
using Diagnosis.Application.UseCases.Notification;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {

       
        [HttpGet("user-notifications")]
        public async Task<IActionResult> GetUserNotifications(
            [FromServices] GetUserNotificationsUseCase getUserNotificationsUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var notifications = await getUserNotificationsUseCase.ExecuteAsync(userId);
            return Ok(notifications);
        }
       
        
        [HttpPost("mark-all-as-read")]
        public async Task<IActionResult> MarkAllNotificationsAsRead(
            [FromServices] MarkNotificationsAsDoneUseCase markNotificationsAsDoneUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var result = await markNotificationsAsDoneUseCase.ExecuteAsync(userId);
            return Ok(result);
        }
    }
}