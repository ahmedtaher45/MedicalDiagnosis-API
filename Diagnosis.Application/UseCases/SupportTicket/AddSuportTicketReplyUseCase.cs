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
        public async Task AddSupportTicketReplyAsync(SupportTicketReplyDTO supportTicketReplyDTO)
        {
            var user = await _unitOfWork.Users.GetByIdAsync([supportTicketReplyDTO.userId]);
            var userRole = await _unitOfWork.Users.GetUserRoleAsync(user.Id);
            if(userRole == "Doctor")
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = supportTicketReplyDTO.userId,
                Title = "Admin Response Received",
                Message = "Inquiry reviewed and case updated. Please check for assessment.",
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Admin,
                Date = DateTime.UtcNow,
                RelatedId = supportTicketReplyDTO.TicketId
            });
            else if(userRole == "User")
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = supportTicketReplyDTO.userId,
                Title = " Response Received",
                Message = "Your response has been recorded. Please wait for further updates.",
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Admin,
                Date = DateTime.UtcNow,
                RelatedId = supportTicketReplyDTO.TicketId
            });
            await _unitOfWork.SupportTicket.AddSupportTicketReplyAsync(supportTicketReplyDTO);
        }
    }
}
