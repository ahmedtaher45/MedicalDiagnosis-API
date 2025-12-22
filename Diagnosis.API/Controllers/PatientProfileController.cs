using Diagnosis.Application.Services.ProfileService;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientProfileController: ControllerBase
    {
        private readonly PatientProfileService _service;

        public PatientProfileController(PatientProfileService service)
        {
            _service = service;
        }

        // Patient Profile - History
        [HttpGet("{patientId}/history")]
        public async Task<IActionResult> GetPatientHistory(int patientId)
        {
            var history = await _service.GetPatientHistory(patientId);
            return Ok(history);
        }
    }
}
