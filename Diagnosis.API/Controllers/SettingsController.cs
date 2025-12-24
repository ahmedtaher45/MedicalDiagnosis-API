using Diagnosis.Application.Services.EmailService;
using Diagnosis.Application.UseCases;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.WebUtilities;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.DTOs.DrugChecker;
using Diagnosis.Application.UseCases.DrugChecker;
using Diagnosis.Application.UseCases.Settings;
using Diagnosis.Application.DTOs.Settings;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        [Authorize(Roles = "Patient")]
        [HttpGet("profile")]
         
        public async Task<IActionResult> GetProfile(
    [FromServices] GetProfileUseCase getProfileUseCase)
{
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    Console.WriteLine("User ID: " + userId);

    if (userId == null)
        return Unauthorized();

    var profile = await getProfileUseCase.GetPatientProfile(userId);

    if (profile == null)
        return NotFound(new { message = "Profile not found" });

    return Ok(profile);
}
        [Authorize(Roles = "Patient")]
        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile(
            [FromServices] UpdateProfileUseCase updateProfileUseCase,
            [FromBody] ProfileDto ProfileDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var result = await updateProfileUseCase.UpdatePatientProfile(userId, ProfileDto);

            if (!result)
                return NotFound(new { message = "Profile not found or update failed" });

            return NoContent();
        }
    }
}