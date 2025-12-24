
using Diagnosis.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("api/doctor/dashboard")]
    [Authorize(Roles = "Doctor")]
    [Produces("application/json")]
    public class DoctorDashboardController : ControllerBase
    {
        private readonly IDoctorDashboardService _dashboardService;

        public DoctorDashboardController(IDoctorDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        
        [HttpGet]
        [ProducesResponseType(typeof(DoctorDashboardDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetDashboard()
        {
            try
            {
                // الحصول على doctorId من الـ JWT
                var doctorIdClaim = User.FindFirst("uid")?.Value;
                if (doctorIdClaim == null)
                    return Unauthorized(new { message = "Doctor ID not found in token" });

                if (!int.TryParse(doctorIdClaim, out int doctorId))
                    return BadRequest(new { message = "Invalid Doctor ID in token" });

                var result = await _dashboardService.GetDashboardAsync(doctorId);

                if (result == null)
                    return NotFound(new { message = "Dashboard data not found" });

                return Ok(result);
            }
            catch (System.Exception ex)
            {
             
                return StatusCode(500, new { message = "An error occurred", detail = ex.Message });
            }
        }
    }

   
    public class DoctorDashboardDto
    {
        public int TotalPatients { get; set; }
        public int PendingAppointments { get; set; }
        public double AverageRating { get; set; }
        public string[] RecentNotifications { get; set; } = new string[0];
    }
}

