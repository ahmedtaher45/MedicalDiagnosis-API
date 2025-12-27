using Diagnosis.Application.DTOs.Faq;
using Diagnosis.Application.UseCases.Faq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFaqs([FromQuery]FaqDTO faqDTO, [FromQuery] string? search , [FromServices] GetFaqsUseCase faqsUseCase)
        {
            var faqs = await faqsUseCase.GetAllFaqAsync(faqDTO, search);
            return Ok(faqs);
        }
    }
}
