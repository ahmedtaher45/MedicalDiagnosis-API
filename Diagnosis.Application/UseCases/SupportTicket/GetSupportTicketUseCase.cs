using Diagnosis.Application.DTOs.SupportTicket;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.SupportTicket
{
    public class GetSupportTicketUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSupportTicketUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SupportTicketReplyDTO?> GetSupportTicketByIdAsync(int ticketId)
        {
            var ticket = await _unitOfWork.SupportTicket.GetByIdAsync([ticketId]);
            if (ticket == null) return null;

            return new SupportTicketReplyDTO
            {
                TicketId = ticket.Id,
                userId = ticket.userId,
                Subject = ticket.Subject,
                Details = ticket.Details,
                Reply = ticket.Reply
            };
        }
        
    }
}
