using Diagnosis.Application.DTOs.Auth;
using Diagnosis.Application.DTOs.DoctorManagement;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.UseCases.Auth;
using Diagnosis.Application.UseCases.Profile;
using Diagnosis.Domain.Entites;
using Diagnosis.Infrastracture.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorManagementController: ControllerBase
    {

        
        private readonly ILogger<DoctorManagementController> _logger;
        public DoctorManagementController(ILogger<DoctorManagementController> logger)
        {
            //  _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-doctor")]
        public async Task<IActionResult> AddDoctor(
            [FromServices] AddDoctorUseCase addDoctorUseCase,
            [FromBody] AddDoctorDTO addDoctorDTO
            )
        {
            var result = await addDoctorUseCase.ExecuteAsync(addDoctorDTO);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorProfileAsync(int id,
         [FromServices] GetDoctorUseCase Doctor)
        
        {
            try
            {
                var doctor = await Doctor.GetDoctorProfileAsync(id);

                if (doctor == null)
                {
                    _logger.LogWarning($"Doctor with ID {id} not found");
                    return NotFound(new { message = "الطبيب غير موجود" });
                }

                return Ok(doctor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving doctor profile for ID {id}");
                return StatusCode(500, new { message = $"{ex.Message}حدث خطأ في النظام" });
            }
        }
        ////

        // 2) قائمة الأطباء (لـ Doctors Table)
        [HttpGet]
        public async Task<IActionResult> GetDoctors(
            [FromServices] GetDoctorsListUseCase useCase,
            [FromQuery] string? search,
            [FromQuery] bool? isActive)
        {
            var doctors = await useCase.ExecuteAsync(search, isActive);
            return Ok(doctors);
        }

      
        // 4) تفعيل / إلغاء تفعيل دكتور
        [HttpPatch("status/{id:int}")]
        public async Task<IActionResult> ChangeStatus(
            int id,
            [FromServices] ChangeDoctorStatusUseCase useCase)
        {
            var success = await useCase.ExecuteAsync(id, isActive:false);
            if (!success)
                return NotFound(new { message = "الطبيب غير موجود" });

            return NoContent();
        }

        // 5) Reset Password
        [HttpPost("reset-password/{id:int}")]
        public async Task<IActionResult> ResetPassword(
            int id,
            [FromBody] ResetDoctorPasswordDto model,
            [FromServices] ResetDoctorPasswordUseCase useCase)
        {
            var success = await useCase.ExecuteAsync(id, model.NewPassword);
            if (!success)
                return NotFound(new { message = "الطبيب غير موجود" });

            return NoContent();
        }
    }


} 

