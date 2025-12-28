using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.UseCases.DiagnosisModule;
using Diagnosis.Application.UseCases.Profile;
using Diagnosis.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PatientsController: ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientsController> _logger;

        public PatientsController( ILogger<PatientsController> logger)
        {
          //  _unitOfWork = unitOfWork;
            _logger = logger;
        }




        /// <summary>
        /// احصل على بروفايل مريض
        /// GET: api/patient/{id}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientProfileAsync(int id,
        [FromServices] GetPatientUseCase Patient)
        {
                try
                {
                    var patient = await Patient.GetPatientProfileAsync(id);

                    if (patient == null)
                    {
                        _logger.LogWarning($"Patient with ID {id} not found");
                        return NotFound(new { message = "المريض غير موجود" });
                    }

                    return Ok(patient);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error retrieving patient profile for ID {id}");
                    return StatusCode(500, new { message = $"{ex.Message}حدث خطأ في النظام" });
                 }

        }
    }
}
