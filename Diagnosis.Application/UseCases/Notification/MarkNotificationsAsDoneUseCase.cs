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
    public class MarkNotificationsAsDoneUseCase
    {
         private readonly IUnitOfWork _unitOfWork;
        public MarkNotificationsAsDoneUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<string> ExecuteAsync(string userId)
        {
            var notifications = await _unitOfWork.Notifications.MarkAllAsReadAsync(userId);
            if (notifications)
            {
                return "Notifications marked as read successfully.";
            }
            return "Failed to mark notifications as read.";
        }
    }
}
