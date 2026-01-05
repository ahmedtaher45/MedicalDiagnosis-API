using Diagnosis.Application.DTOs.SupportTicket;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.SupportTicket
{
    public class AddSuportTicketReplyUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSuportTicketReplyUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSupportTicketReplyAsync(AddSupportTicketReplyDTO supportTicketReplyDTO)
        {
            var ticket = await _unitOfWork.SupportTicket.GetByIdAsync([supportTicketReplyDTO.TicketId]);
            var ticketUser = await _unitOfWork.Users.GetByIdAsync([ticket.userId]);
            var userRole = await _unitOfWork.Users.GetUserRoleAsync(ticketUser.Id);

            if(userRole == "Doctor"){
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = ticketUser.Id,
                Title = "Admin Response Received",
                Message = "Inquiry reviewed and case updated. Please check for assessment.",
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Admin,
                Date = DateTime.UtcNow,
                RelatedId = supportTicketReplyDTO.TicketId
            });
            await _unitOfWork.SaveChangesAsync();
        }
            else if(userRole == "Patient"){
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = ticketUser.Id,
                Title = "Admin Response Received",
                Message = "Your consultation has been reviewed, and an administrative response is now available.",
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Admin,
                Date = DateTime.UtcNow,
                RelatedId = supportTicketReplyDTO.TicketId
            });}
            await _unitOfWork.SupportTicket.AddSupportTicketReplyAsync(supportTicketReplyDTO);
        }
    }
}
