using Diagnosis.Application.DTOs;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Application.UseCases;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.WebUtilities;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterDTO registerDTO,
            [FromServices] RegisterUseCase registerUseCase)
        {
            var result = await registerUseCase.ExcuteAsync(registerDTO);
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

        /// <summary>
        /// Change user password - requires authentication
        /// </summary>
        /// <param name="changePasswordDto">Password change request</param>
        /// <returns>Success or error response</returns>
        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(
            [FromBody] ChangePasswordDTO changePasswordDto,
            [FromServices] ChangePasswordUseCase changePasswordUseCase)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new ChangePasswordResponse
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = errors
                });
            }

            // Get user ID from JWT token claims
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new ChangePasswordResponse
                {
                    Success = false,
                    Message = "User not authenticated",
                    Errors = new List<string> { "User not authenticated" }
                });
            }

            var result = await changePasswordUseCase.ExecuteAsync(userId, changePasswordDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
            
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginDTO loginDTO,
            [FromServices] LoginUseCase loginUseCase)
        {
            var result = await loginUseCase.Login(loginDTO);
            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }
        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordDTO forgotPasswordDTO , [FromServices]ForgotPasswordUseCase forgotPasswordUseCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await forgotPasswordUseCase.ForgotPasswordAsync(forgotPasswordDTO);
            return Ok(result);
        }
        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDTO resetPasswordDTO, [FromServices] ResetPasswordUseCase resetPasswordUseCase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await resetPasswordUseCase.ResetPasswordAsync(resetPasswordDTO);
            return Ok(result);
        }

    }
}