using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Inquiry
{
    public class GetInquiryByPatientIdUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;
        private readonly IConfiguration _config;
        public GetInquiryByPatientIdUseCase(IUnitOfWork unitOfWork, IConfiguration config, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _config = config;
            _fileService = fileService;
        }

        public async Task<GetInquiryDTO> ExecuteAsync(int patientId, int inquiryId)
        {
            try
            {
                var inquiry = await _unitOfWork.Inquiry.GetAsync(c => c.Id == inquiryId
                && c.PatientId == patientId
                );

                if (inquiry == null) throw new ArgumentNullException(nameof(inquiry));

                var baseUrl = _config.GetSection("BaseUrl");

                var files = inquiry.InquiryFiles?
                    .Select(path => $"{baseUrl}/{path}")
                    .ToList()
                    ?? new List<string>();

                var dto = new GetInquiryDTO();

                dto.DoctorId = patientId;
                dto.Reply = inquiry.Reply;
                dto.Description = inquiry.Description;
                dto.Date = inquiry.CreatedOn;
                dto.Symptoms = inquiry.Symptoms;
                dto.Files = files;

                if (inquiry.Status == Domain.Models.Entites.ConsultationStatus.Pending)
                {
                    dto.Status = "In Progress";
                }
                else if (inquiry.Status == Domain.Models.Entites.ConsultationStatus.Rejected)
                {
                    dto.Status = "Replied";
                    dto.RejectReason = inquiry.RejectReason;
                    dto.RejectNotes = inquiry.RejectNotes;
                }
                else
                {
                    dto.Status = "Replied";
                }
                return dto;
            }
            catch (Exception ex)
            {

                throw new Exception("Error with fetching Inquiry: " + ex);
            }
        }

    }
}
