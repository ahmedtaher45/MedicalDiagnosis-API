using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.UseCases.Profile;
using Diagnosis.Domain.Entites;
using Diagnosis.Infrastracture.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorsController: ControllerBase
    {

      
        
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(ILogger<DoctorsController> logger)
        {
            //  _unitOfWork = unitOfWork;
            _logger = logger;
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


       
    }      
}

