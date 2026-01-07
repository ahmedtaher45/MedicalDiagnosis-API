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
using Diagnosis.Application.UseCases.PhysiotherapyExercise;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PhysiotherapyExerciseController : ControllerBase
    {
        [Authorize(Roles ="Patient")]
        [HttpGet("list")]
        public async Task<IActionResult> GetAllPhysiotherapyExercises(
            [FromServices] GetPhysiotherapyExerciseUseCase getPhysiotherapyExerciseUseCase)
        {
            var exercises = await getPhysiotherapyExerciseUseCase.GetAllExercises();

            if (exercises == null || !exercises.Any())
                return NotFound(new { message = "No exercises found" });

            return Ok(exercises);
        }
        [Authorize(Roles = "Patient")]
        [HttpPost("end-session")]
        public async Task<IActionResult> EndPhysiotherapySession(
            [FromServices] EndPhysiotherapySessionUseCase endPhysiotherapySessionUseCase)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var result = await endPhysiotherapySessionUseCase.EndPhysiotherapySessionAsync(userId);
            return Ok(new { message = result });
        }

        [Authorize(Roles = "Patient")]
        [HttpPost("submit-video")]
        public async Task<IActionResult> SubmitPhysiotherapyVideo(
            [FromServices] SubmitPhysiotherapyVideoUseCase submitPhysiotherapyVideoUseCase,
            [FromForm] IFormFile videoFile,
            [FromForm] string exerciseName)
        {
            if (videoFile == null || videoFile.Length == 0)
            {
                return BadRequest(new { message = "No video file provided" });
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!.ToString();
            var result = await submitPhysiotherapyVideoUseCase.SubmitVideoAsync(videoFile, exerciseName, userId);
            return Ok(new { message = result });
        }
    }
}