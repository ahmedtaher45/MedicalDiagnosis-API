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
    public class ConsultationController : ControllerBase
    {
        private readonly ConsultationUseCase _consultationUseCase;

        public ConsultationController(ConsultationUseCase consultationUseCase)
        {
            _consultationUseCase = consultationUseCase;
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetConsultationsByDoctorId(
            [FromRoute] int doctorId)
        {
            var consultations = await _consultationUseCase.GetDoctorConsultations(doctorId);
            return Ok(consultations);
        }

       [Authorize(Roles = "Doctor")]
       [HttpPost("reject/{consultationId}")]
       public async Task<IActionResult> RejectConsultation(
           [FromBody] RejectConsultationDTO rejectConsultationDTO,
              [FromRoute] int consultationId)
       {
           var result = await _consultationUseCase.RejectConsultation(rejectConsultationDTO, consultationId);
           if (!result.Success)
               return BadRequest(result.ErrorMessage);

           return Ok(result);
       }
       [Authorize(Roles = "Doctor")]
       [HttpPost("modify/{consultationId}")]
       public async Task<IActionResult> ModifyConsultation(
           [FromBody] ModifyConsultationDTO modifyConsultationDTO,
           [FromRoute] int consultationId)
       {
           var result = await _consultationUseCase.ModifyConsultationAsync(modifyConsultationDTO, consultationId);
           if (!result.Equals("Consultation modified successfully"))
               return BadRequest();

           return Ok(result);
       }
       
       [Authorize(Roles = "Doctor")]
       [HttpGet("details/{consultationId}")]
       public async Task<IActionResult> GetConsultationDetails(
           [FromRoute] int consultationId)
       {
           var result = await _consultationUseCase.GetModifyDataAsync(consultationId);
           if (!result.Success)
               return BadRequest(result.ErrorMessage);

           return Ok(result);
       }
       [Authorize(Roles = "Doctor")]
       [HttpPost("accept/{consultationId}")]
       public async Task<IActionResult> AcceptConsultation(
           [FromRoute] int consultationId)
       {
          var result = await _consultationUseCase.AcceptConsultation(consultationId);
           if (!result.Success)
               return BadRequest(result.ErrorMessage);

           return Ok(result);
       }
       //get modify data
       [Authorize(Roles = "Doctor")]
       [HttpPost("modify-data/{consultationId}")]
       public async Task<IActionResult> GetModifyData(
           [FromRoute] int consultationId)
       {
           var result = await _consultationUseCase.GetModifyDataAsync(consultationId);
           if (!result.Success)
               return BadRequest(result.ErrorMessage);

           return Ok(result);
       }

    }

    
}