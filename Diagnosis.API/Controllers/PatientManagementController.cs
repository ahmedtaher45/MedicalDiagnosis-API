   using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.UseCases.DoctorDashboard;
using Diagnosis.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.API.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class PatientManagementController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientManagementController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PatientProfileDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPatientProfile(int id)
        {
            try
            {
                var patient = await _unitOfWork.Patient.GetPatientProfileAsync(id);

                if (patient == null)
                {
                    return NotFound(new { message = "المريض غير موجود" });
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "حدث خطأ في النظام" });
            }
        }
        [HttpPost("Get-Patients")]
        public async Task<IActionResult>GetPatientsAsync([FromBody]PatientSearchDTO patientSearchDTO , [FromServices] GetPatientsUseCase getPatientsUseCase)
        {
            var result = await getPatientsUseCase.GetPatientsAsync(patientSearchDTO);
            return Ok(result);
        }
        [HttpGet("{patientId}/Get-PatientProfile")]
        public async Task<IActionResult> GetPatientProfileAsync([FromRoute]int patientId , [FromServices] GetPatientProfileUseCase getPatientProfileUseCase)
        {
            var result = await getPatientProfileUseCase.GetPatientProfileAsync(patientId);
            return Ok(result);
        }
    }

}
