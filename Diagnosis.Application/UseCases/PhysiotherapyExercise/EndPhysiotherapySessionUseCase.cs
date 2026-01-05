using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.DTOs.Settings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.PhysiotherapyExercise
{
    public class EndPhysiotherapySessionUseCase
    {
         private readonly IUnitOfWork _unitOfWork;
        public EndPhysiotherapySessionUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }
        public async Task<string> EndPhysiotherapySessionAsync(string userId)
        {
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = userId,
                Title = "Physiotherapy Session Completed",
                Message = "Your physiotherapy session has been successfully completed. Great job!",
                Date = DateTime.UtcNow,
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Physiotherapy,
              
            });
            await _unitOfWork.SaveChangesAsync();
            return "Physiotherapy session ended successfully.";
        }

    }}