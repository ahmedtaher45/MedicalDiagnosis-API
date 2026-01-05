using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Diagnosis.Application.DTOs.Consultation;
using Diagnosis.Application.DTOs.PatientDashboard;

namespace Diagnosis.Infrastracture.Repositories
{
    public class ConsultationRepository : Repository<Inquiry>, IConsultationRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        
        public IQueryable<Inquiry> GetQueryable()
        {
            return _context.Inquiries.AsQueryable();
        }

        public async Task<List<Inquiry>> GetByDoctorIdAsync(int doctorId)
        {
            return await _context.Inquiries
                .Where(c => c.DoctorId == doctorId)
                .Include(c => c.Patient)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Inquiry>> GetByPatientIdAsync(int patientId)
        {
            return await _context.Inquiries
                .Where(c => c.PatientId == patientId)
                .Include(c => c.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<Inquiry>> GetByStatusAsync(ConsultationStatus status)
        {
            return await _context.Inquiries
                .Where(c => c.Status == status)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Inquiry?> GetDetailsAsync(int inquiryId)
        {
            return await _context.Inquiries
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .FirstOrDefaultAsync(c => c.Id == inquiryId);
        }

        public async Task<ConsultationDetailsDTO> GetConsultationDetailsAsync(int inquiryId)
        {
            var inquiry = await _context.Inquiries
                .Include(c => c.Patient)
                .Include(c => c.Doctor)
                .FirstOrDefaultAsync(c => c.Id == inquiryId);

            if (inquiry == null)
            {
                return new ConsultationDetailsDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            return new ConsultationDetailsDTO
            {
                Id = inquiry.Id,
                PatientName = inquiry.Patient.FName + " " + inquiry.Patient.LName,
                PatientBirthDate = inquiry.Patient.DateOfBirth,
                PatientGender = inquiry.Patient.Gender,
                Description = inquiry.Reply,
                Attachments = inquiry.InquiryFiles.ToList(),
                Symptoms = inquiry.Symptoms,
                Response = inquiry.Reply,
                RequestDate = inquiry.CreatedOn,
                Success = true
            };
        }

        public async Task<ConsultationResponseDTO> RejectConsultationAsync(RejectConsultationDTO dto, int inquiryId)
        {
            var inquiry = await _context.Inquiries.FindAsync(inquiryId);
            if (inquiry == null)
            {
                return new ConsultationResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            inquiry.Status = ConsultationStatus.Rejected;
            inquiry.RejectReason = dto.Reason;
            inquiry.RejectNotes = dto.Notes;

            _context.Inquiries.Update(inquiry);
            await _context.SaveChangesAsync();

            return new ConsultationResponseDTO
            {
                Success = true
            };
        }

        public async Task<ModifyConsultationDTO> GetModifyDataAsync(int consultationId)
        {
            var consultation = await _context.Inquiries
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(c => c.Id == consultationId);

            if (consultation == null)
            {
                return new ModifyConsultationDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            return new ModifyConsultationDTO
            {
                ConsultationId = consultation.Id,
                Name = consultation.Patient.FName + " " + consultation.Patient.LName,
                Description = consultation.Symptoms,
                Reply = consultation.Reply,
                Success = true
            };
        }

        public async Task<ModifyConsultationResponseDTO> ModifyConsultationAsync(
            ModifyConsultationRequestDTO dto,
            int consultationId)
        {
            var consultation = await _context.Inquiries.FindAsync(consultationId);
            if (consultation == null)
            {
                return new ModifyConsultationResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            consultation.Symptoms = dto.Description;
            consultation.Reply = dto.Reply;

            _context.Inquiries.Update(consultation);
            await _context.SaveChangesAsync();

            return new ModifyConsultationResponseDTO
            {
                Success = true
            };
        }

        public async Task<ConsultationResponseDTO> AcceptConsultationAsync(int consultationId)
        {
            var consultation = await _context.Inquiries.FindAsync(consultationId);
            if (consultation == null)
            {
                return new ConsultationResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            consultation.Status = ConsultationStatus.Accepted;
            _context.Inquiries.Update(consultation);
            await _context.SaveChangesAsync();

            return new ConsultationResponseDTO
            {
                Success = true
            };
        }
      
        public async Task<ConsultationResponseDTO> CancelConsultationAsync(int consultationId)
        {
            var consultation = await _context.Inquiries.FindAsync(consultationId);
            if (consultation == null)
            {
                return new ConsultationResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Consultation not found"
                };
            }

            consultation.Status = ConsultationStatus.Canceled;
            _context.Inquiries.Update(consultation);
            await _context.SaveChangesAsync();

            return new ConsultationResponseDTO
            {
                Success = true
            };
        }
        public async Task<int> GetDoctorAsync(string userId)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(p => p.UserId == userId);
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));
            return doctor.Id;
        }
        
        public async Task<Dictionary<string, int>> GetConsultationCountByDayAsync(int patientId)
        {

            var today = DateTime.UtcNow.Date;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            var startOfWeek = today.AddDays(-diff);
            var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);

            var consultations = await _context.Inquiries
                .Where(c => c.CreatedOn >= startOfWeek && c.CreatedOn <= endOfWeek && c.PatientId == patientId)
                .GroupBy(c => c.CreatedOn.Value.Date)
                .Select(g => new
                {
                    Date = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return consultations.ToDictionary(c => c.Date.DayOfWeek.ToString(), c => c.Count);
        }
        
        public async Task<TopSymptomsDTO> GetTopSymptomsThisWeek(int patientId)
        {
            var today = DateTime.UtcNow.Date;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
            var startOfWeek = today.AddDays(-diff);
            var endOfWeek = startOfWeek.AddDays(7).AddTicks(-1);

            var symptoms = await _context.Inquiries
                .Where(c => c.CreatedOn >= startOfWeek && c.CreatedOn <= endOfWeek && c.PatientId == patientId)
                .Select(c => c.Symptoms)
                .ToListAsync();

              
              

            var topSymptom = symptoms.GroupBy(s => s)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .Take(1)
                .SingleOrDefault();

                  //parse by comma and get only first symptom
                  var firstSymptom = topSymptom?.Split(",").FirstOrDefault()?.Trim();
            return new TopSymptomsDTO
            {
                Symptom = firstSymptom
            };
        }


        


    }
}
