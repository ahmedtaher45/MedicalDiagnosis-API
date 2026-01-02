 using Diagnosis.Application.DTOs.SupportTicket;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.SupportTicket
{
    public class AddSupportTicketUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSupportTicketUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public async Task CreateSupportTicketAsync(string role,string userId , SupportTicketDTO supportTicketDTO)
        {
            var admins = await _unitOfWork.Users.GetUsersByRoleAsync("Admin");
            var user = await _unitOfWork.Users.GetByIdAsync([userId]);

            foreach (var admin in admins)
            {
                await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
                {
                    UserId = admin.Id,
                    Title = $"{role} sent a help request",
                    Message = $"New support ticket from {(role == "Patient" ? user.UserName : "Dr. " + user.UserName)} Subject: {supportTicketDTO.Subject}",
                    NotificationType = Diagnosis.Domain.Entites.NotificationType.SupportTicket,
                    Date = DateTime.UtcNow,
                  
                });
            }
            

            await _unitOfWork.SupportTicket.CreateSupportTicketAsync(supportTicketDTO , userId);
        }
    }
}
