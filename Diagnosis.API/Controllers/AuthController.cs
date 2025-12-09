using Diagnosis.Application.DTOs;
using Diagnosis.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterDTO registerDTO,
            [FromServices] RegisterUseCase registerUseCase)
        {
            var result = await registerUseCase.ExcuteAsync(registerDTO);
            return Ok(result);
        }
    }
}
