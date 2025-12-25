using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class InquiryRepository: Repository<Consultation>, IInquiryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public InquiryRepository(ApplicationDbContext context, IFileService fileService) : base(context)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<IquiryResponse> AddInquiryAsync(AddInquiryDTO addInquiryDTO, string userId)
        {
            var fileUrls = await _fileService.UploadMultipleFilesAsync(addInquiryDTO.Files!);

            var patient =  await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
            if (patient == null)
            {
                return new IquiryResponse
                {
                    Success = false,
                    Message = "No patient with this Id"
                };
            }

            try
            {
                await _context.Consultations.AddAsync(
                new Consultation
                {
                    PatientId = patient.Id,
                    DoctorId = addInquiryDTO.DoctorId,
                    Symptoms = addInquiryDTO.Symptoms,
                    Notes = addInquiryDTO.Notes,
                    Status = ConsultationStatus.Pending,
                    Type = ConsultationType.Inquiry,
                    Date = DateTime.Now,
                    FileUrls = fileUrls
                });
            }
            catch (Exception ex)
            {
                return new IquiryResponse
                {
                    Success = false,
                    Message = "Error with adding Inquiry" + ex.Message
                };
            }

            return new IquiryResponse
            {
                Success = true,
                Message = "Inquiry sent successfully"
            };
        }
        public async Task<int> GetPatientAsync(string userId)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.UserId == userId);
            if (patient == null)
                throw new ArgumentNullException(nameof(patient));
            return patient.Id;
        }
    }
}
