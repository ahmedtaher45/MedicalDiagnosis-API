using Diagnosis.Application.Interfaces;
using Diagnosis.Application.DTOs.Consultation;



namespace Diagnosis.Application.UseCases.Consultation
{
    public class ModifyConsultationsUseCase 
    {
        private readonly IUnitOfWork _unitOfWork;

        public ModifyConsultationsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ModifyConsultationResponseDTO> ModifyConsultation(int consultationId, ModifyConsultationRequestDTO modifyConsultationRequestDTO)
        {
            var consultation = await _unitOfWork.Consultation.GetByIdAsync([consultationId]);
            await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
            {
                UserId = consultation.Patient.User.Id,
                Title = "Doctor Response Received",
                Message = "Your doctor has replied to your consultation. You can view the response now.",
                NotificationType = Diagnosis.Domain.Entites.NotificationType.Medical,
                Date = DateTime.UtcNow,
               
            });
            return await _unitOfWork.Consultation.ModifyConsultationAsync(modifyConsultationRequestDTO, consultationId);
        }

    }
}