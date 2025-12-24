using Diagnosis.Application.UseCases.Dashboard;
using Diagnosis.Application.UseCases.Dashboard.AdminDashboard;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers.AdminControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminDashboardController : ControllerBase
    { 
        private readonly GetDashboardStatsUseCase _getDashboardStatsUseCase;
        private readonly GetAppointmentsOverTimeUseCase _getAppointmentsOverTimeUseCase;
        private readonly GetTopDoctorsUseCase _getTopDoctorsUseCase;
        private readonly GetRecentAppointmentsUseCase _getRecentAppointmentsUseCase;

        public AdminDashboardController(
            GetDashboardStatsUseCase getDashboardStatsUseCase,
            GetAppointmentsOverTimeUseCase getAppointmentsOverTimeUseCase,
            GetTopDoctorsUseCase getTopDoctorsUseCase,
            GetRecentAppointmentsUseCase getRecentAppointmentsUseCase)
        {
            _getDashboardStatsUseCase = getDashboardStatsUseCase;
            _getAppointmentsOverTimeUseCase = getAppointmentsOverTimeUseCase;
            _getTopDoctorsUseCase = getTopDoctorsUseCase;
            _getRecentAppointmentsUseCase = getRecentAppointmentsUseCase;
        }

       
        [HttpGet("stats")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var stats = await _getDashboardStatsUseCase.ExecuteAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving dashboard stats", error = ex.Message });
            }
        }

       
        [HttpGet("appointments-over-time")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAppointmentsOverTime()
        {
            try
            {
                var data = await _getAppointmentsOverTimeUseCase.ExecuteAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving appointments over time", error = ex.Message });
            }
        }

        [HttpGet("top-doctors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTopDoctors()
        {
            try
            {
                var data = await _getTopDoctorsUseCase.ExecuteAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving top doctors", error = ex.Message });
            }
        }

        [HttpGet("recent-appointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRecentAppointments([FromQuery] int count = 10)
        {
            try
            {
                if (count < 1 || count > 100)
                    return BadRequest(new { message = "Count must be between 1 and 100" });

                var appointments = await _getRecentAppointmentsUseCase.ExecuteAsync(count);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error retrieving recent appointments", error = ex.Message });
            }
        }
    }
}
