using Diagnosis.Application.DTOs;
using Diagnosis.Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diagnosis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportTicketController : ControllerBase
    {
        [HttpPost]
        public async Task CreateSupportTicketAsync([FromBody]SupportTicketDTO supportTicketDTO , [FromServices]SupportTicketUseCase supportTicketUseCase)
        {
           var result =   supportTicketUseCase.CreateSupportTicketAsync(supportTicketDTO);
           await result;
            
        }
    }
}
