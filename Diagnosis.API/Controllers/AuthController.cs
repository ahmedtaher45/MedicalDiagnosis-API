using Diagnosis.Application.DTOs;
using Diagnosis.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUseCase registerUseCase;
        private readonly ChangePasswordUseCase changePasswordUseCase;

        public AuthController(
            RegisterUseCase registerUseCase,
            ChangePasswordUseCase changePasswordUseCase)
        {
            this.registerUseCase = registerUseCase;
            this.changePasswordUseCase = changePasswordUseCase;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterDTO registerDTO,
            [FromServices] RegisterUseCase registerUseCase)
        {
            return Ok();
        }

        /// <summary>
        /// Change user password - requires authentication
        /// </summary>
        /// <param name="changePasswordDto">Password change request</param>
        /// <returns>Success or error response</returns>
        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO changePasswordDto)
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
    }
}