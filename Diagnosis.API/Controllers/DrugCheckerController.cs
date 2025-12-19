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
using Diagnosis.Application.Interfaces;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DrugCheckerController : ControllerBase
    {
        private readonly IDrugCheckerProvider _drugCheckerProvider;

        public DrugCheckerController(IDrugCheckerProvider drugCheckerProvider)
        {
            _drugCheckerProvider = drugCheckerProvider;
        }

        [Authorize(Roles = "Patient")]
        [HttpGet("check")]
        public async Task<IActionResult> CheckDrug(
            [FromBody] DrugCheckerRequestDTO requestDTO)
        {
            var result = await _drugCheckerProvider.CheckDrugAsync(requestDTO);
            if (result == null || !result.Success)
            {
                return BadRequest(result?.ErrorMessage ?? "Error checking drug");
            }
            return Ok(result);
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("suggestions")]
        public async Task<IActionResult> GetSearchSuggestions(
            [FromQuery] string keyword)
        {
            var result = await _drugCheckerProvider.GetSuggestionsAsync(keyword);
            if (result == null || !result.Any())
            {
                return NotFound("No suggestions found");
            }
            return Ok(result);
        }
    }
}