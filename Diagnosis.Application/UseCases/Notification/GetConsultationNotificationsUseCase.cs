using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.Notification;
using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.DTOs.Settings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Notification
{
    public class GetConsultationNotificationsUseCase
    {
         private readonly IUnitOfWork _unitOfWork;
        public GetConsultationNotificationsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<List<NotificationDto>> ExecuteAsync(string userId)
        {
            var notifications = await _unitOfWork.Notifications.GetUserConsultationNotificationsAsync(userId);
            if (notifications == null || notifications.Count == 0)
            {
                return new List<NotificationDto>
                {
                    new NotificationDto
                    {
                        Success = false,
                        ErrorMessage = "No notifications found."
                    }
                };
            }
            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Title = n.Title,
                Message = n.Message,
                Date = n.Date,
                Success = true,
                ErrorMessage = null
            }).ToList();
        }
    }
}
