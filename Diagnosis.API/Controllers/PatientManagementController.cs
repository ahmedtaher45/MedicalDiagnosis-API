using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.UseCases.DiagnosisModule;
using Diagnosis.Application.UseCases.Profile;
using Diagnosis.Domain.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class PatientManagementController: ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientManagementController> _logger;

        public PatientManagementController( ILogger<PatientManagementController> logger)
        {
          //  _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // 1) Patient Table (قائمة المرضى)
        [HttpGet]
        public async Task<IActionResult> GetPatients(
            [FromServices] GetPatientsListUseCase useCase,
            [FromQuery] string? search,
            [FromQuery] string? status)   // "All" / "Active" / "Deleted"
        {
            var patients = await useCase.ExecuteAsync(search, status);
            return Ok(patients);
        }


        /// <summary>
        /// احصل على بروفايل مريض
        /// GET: api/patient/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPatientProfileAsync(int id,   [FromServices] GetPatientUseCase useCase)
    
 
        {

            try
            {
                var patient = await useCase.GetPatientProfileAsync(id);

                if (patient == null)
                {
                    _logger.LogWarning("Patient with ID {Id} not found", id);
                    return NotFound(new { message = "المريض غير موجود" });
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving patient profile for ID {Id}", id);
                return StatusCode(500, new { message = "حدث خطأ في النظام" });
            }
        }
        // 3) Delete Patient (تحويله لحالة Deleted)
        [HttpPatch("status/{id:int}")]
        public async Task<IActionResult> DeletePatient(
            int id,
            [FromServices] ChangePatientStatusUseCase useCase)
        {
            var ok = await useCase.ExecuteAsync(id, isDeleted: true);
            if (!ok)
                return NotFound(new { message = "المريض غير موجود" });

            return NoContent();
        }
    }
}