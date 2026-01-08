using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.UseCases.PatientDashboard.cs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDashboardController : ControllerBase
    {
        [HttpGet("Get-DoctorList")]
        public async Task<IActionResult> GetDoctorList([FromServices] DoctorListUseCase doctorListUseCase)
        {
            var result = await doctorListUseCase.GetDoctorList();
            return Ok(result);
        }
    }
}
