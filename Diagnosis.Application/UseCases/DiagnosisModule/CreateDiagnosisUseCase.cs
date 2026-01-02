using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.DiagnosisModule
{
    public class CreateDiagnosisUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDiagnosisUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProviderResponse> ExecuteAsync(CreateDiagnosisDTO createDiagnosisDTO, string userId)
        {
            // var doctor = await _unitOfWork.Doctor.GetByIdAsync(new object[] { userId });
            // await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            // {
            //     UserId = doctor.UserId,
            //     Title = "New AI Consultation Submitted",
            //     Message = "A patient has sent an AI-assisted consultation for your review.",
            //     NotificationType = NotificationType.Consultation,
            //     Date = DateTime.UtcNow
            // });

            var canUseAI = await _unitOfWork.SystemSettings.CanUseAiAsync(userId);
            if (!canUseAI)
            {
                return new ProviderResponse
                {
                    Success = false,
                    Message = "You have reached the limit of using AI requests per day"
                };
            }

            return await _unitOfWork.DiagnosisModule.CreateDiagnosisAsync(createDiagnosisDTO, userId);
        }
    }
}
