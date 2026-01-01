using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.Notification;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diagnosis.Application.UseCases.Inquiry
{
    public class AddInquiryUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddInquiryUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IquiryResponse> ExecuteAsync(AddInquiryDTO addInquiryDTO, string userId)
{
    if (addInquiryDTO == null)
        throw new ArgumentNullException(nameof(addInquiryDTO));

    var response = await _unitOfWork.Inquiry.AddInquiryAsync(addInquiryDTO, userId);

    var doctor = await _unitOfWork.Doctor.GetByIdAsync(new object[] { addInquiryDTO.DoctorId });

    if (doctor == null)
    {
        return new IquiryResponse
        {
            Success = false,
            Message = "No doctor with this Id"
        };
    }

    var notification = new Diagnosis.Domain.Entites.Notification
    {
        UserId = doctor.UserId,
        Title = "New Patient Inquiry Received",
        Message = "A patient has submitted a new inquiry. Please review and respond.",
        NotificationType = NotificationType.Consultation,
        Date = DateTime.UtcNow
    };

    await _unitOfWork.Notifications.AddAsync(notification);
    await _unitOfWork.SaveChangesAsync();

    return response;
}

    }
}
