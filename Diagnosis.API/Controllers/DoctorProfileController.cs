using Diagnosis.Application.Services.ProfileService;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorProfileController : ControllerBase // 
    {

        private readonly DoctorProfileService _service;

        public DoctorProfileController(DoctorProfileService service)
        {
            _service = service;
        }

        [HttpGet("{doctorId}/history")]
        public async Task<IActionResult> GetDoctorHistory(int doctorId)
        {
            var history = await _service.GetDoctorHistory(doctorId);
            return Ok(history);
        }

        [HttpGet("{doctorId}/statistics")]
        public async Task<IActionResult> GetStatistics(int doctorId)
        {
            var stats = await _service.GetDoctorStatistics(doctorId);
            return Ok(stats);
        }
    }
}
