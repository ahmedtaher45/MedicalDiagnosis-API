using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases
{
    public class SupportTicketUseCase
    {
        private readonly ISupportTicket supportTicket;
        public SupportTicketUseCase(ISupportTicket supportTicket)
        {
            this.supportTicket = supportTicket;
        }

        public async Task CreateSupportTicketAsync(SupportTicketDTO supportTicketDTO)
        {
            await supportTicket.CreateSupportTicketAsync(supportTicketDTO);
        }
    }
}
