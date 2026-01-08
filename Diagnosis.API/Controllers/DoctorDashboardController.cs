using Diagnosis.Application.UseCases.Dashboard.DoctorDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Diagnosis.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Doctor")]
    public class DoctorDashboardController : ControllerBase
    {
        private readonly GetDoctorDashboardUseCase _useCase;

        public DoctorDashboardController(GetDoctorDashboardUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            
            
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                    if (string.IsNullOrEmpty(userId))
                        return Unauthorized(new { message = "Invalid user" });

                var data = await _useCase.ExecuteAsync(userId);
                return Ok(data);
            
        }
    }
}