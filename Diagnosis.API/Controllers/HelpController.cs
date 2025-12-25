using Diagnosis.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFaqs([FromQuery] string? search , [FromServices] FaqUseCase faqsUseCase)
        {
            var faqs = await faqsUseCase.GetAllFaqAsync(search);
            return Ok(faqs);
        }
    }
}
