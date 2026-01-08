using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.DTOs.Settings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.PhysiotherapyExercise
{
    public class SubmitPhysiotherapyVideoUseCase
    {
         private readonly IUnitOfWork _unitOfWork;
         private readonly IPhysiotherapyProvider _physiotherapyProvider;
        public SubmitPhysiotherapyVideoUseCase(IUnitOfWork unitOfWork, IPhysiotherapyProvider physiotherapyProvider)
        {
            _unitOfWork = unitOfWork;
            _physiotherapyProvider = physiotherapyProvider;
         
        }
        public async Task<AIResponseDto> SubmitVideoAsync(IFormFile videoFile, string exerciseName, string userId)
        {
        try{
    
            var response= await _unitOfWork.Physiotherapy.SubmitPhysiotherapyVideoAsync(videoFile, exerciseName, userId);
            if (response.Success)
            {
                await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
                {
                    UserId = userId,
                    Title = "Video Submitted Successfully",
                    Message = $"Your video for the exercise '{exerciseName}' has been submitted successfully.",
                    Date = DateTime.UtcNow,
                    NotificationType = Diagnosis.Domain.Entites.NotificationType.Physiotherapy,
                });
                await _unitOfWork.SaveChangesAsync();
               
            }
             return response;
            }
            catch(Exception ex)
            {
                 return new AIResponseDto
                        {
                            Success = false,
                            Message = ex.Message
                        };
            }

            
           
            
        }
    }
}