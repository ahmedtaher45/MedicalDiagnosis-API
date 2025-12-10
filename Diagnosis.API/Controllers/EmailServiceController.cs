using Diagnosis.Application.DTOs;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        public EmailServiceController(IEmailSender emailSender , UserManager<ApplicationUser> userManager)
        {
             _emailSender = emailSender;
             _userManager = userManager;
        }
        [HttpGet]
        public IActionResult SendEmail()
        {
            try
            {
                var message = new Message(new string[] { "monanagib5555@gmail.com" }, "Test email", "This is the content from our email." , null);
                _emailSender.SendEmail(message);
                return Ok("Email Sent successfully");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        public IActionResult Create([FromForm] List<IFormFile> formFiles)
        {
            try
            {
                var fileCollection = new FormFileCollection();

                if (formFiles != null && formFiles.Any())
                {
                    foreach (var file in formFiles)
                    {
                        fileCollection.Add(file);
                    }
                }

                var message = new Message(
                    new string[] { "monanagib5555@gmail.com" },
                    "Test email with attachments",
                    "This is the content from our email with attachments.",
                    fileCollection 
                );

                _emailSender.SendEmail(message);

                return Ok("Email Sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("forgotpasword")]
        public async Task<IActionResult> Forgotpasword([FromBody] ForgotPasswordDTO forgotPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(forgotPassword.Email!);

            if (user is null)
            {
                return BadRequest("Invalid Request");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var param = new Dictionary<string, string?>
            {
                {"token" ,  token },
                {"email" , forgotPassword.Email!}
            };

            var callback = QueryHelpers.AddQueryString(forgotPassword.ClientUri!, param);
            var message = new Message([user.Email], "Reset Password token", callback, null);

            _emailSender.SendEmail(message);

            return Ok();
        }
        [HttpPost("resetpasword")]
        public async Task<IActionResult> Resetpasword([FromBody] ResetPasswordDTO resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(resetPassword.Email!);
            if (user is null)
            {
                return BadRequest("Invalid Request");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token!, resetPassword.Password!);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);
                return BadRequest(new {Errors = errors});
            }

            return Ok();

        }

    }
}
