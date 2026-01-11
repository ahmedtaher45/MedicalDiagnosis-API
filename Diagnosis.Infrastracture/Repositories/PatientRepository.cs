using Diagnosis.Application.DTOs.Consultation;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientManagement
    {

        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context)
        {

            _context = context;


        }

        // 1) Patient Table
        public async Task<IEnumerable<PatientListItemDto>> GetPatientsAsync(string? search, string? status)
            
           
        {
            var query = _context.Patients
                .Include(p => p.Inquiries)
                .Include(p => p.BoneFractions)   
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p =>
                    (p.FName + " " + p.LName).Contains(search));

            if (!string.IsNullOrWhiteSpace(status) && status != "All")
            {
                bool isDeleted = status == "Deleted";
                query = query.Where(p => p.IsDeleted == isDeleted);
            }

            return await query
                .Select(p => new PatientListItemDto
                {
                    Id = p.Id,
                    FullName = p.FName + " " + p.LName,
                    BirthDate = p.DateOfBirth,
                    Gender = p.Gender,
                    ProfileImageUrl= p.ProfileImageUrl,
                    DiagnosesCount = p.Inquiries.Count + p.BoneFractions.Count, // Changed from Diagnoses to Consultations
                    LastDiagnosisDate = 
                    p.Inquiries
                        .Select(i => i.CreatedOn)
                        .Concat(
                            p.BoneFractions.Select(b =>b.CreatedOn)
                        )
                        .OrderByDescending(x => x)
                        .FirstOrDefault(),
                    Status = p.IsDeleted ? "Deleted" : "Active"
                })
                .ToListAsync();
        }


        public async Task<PatientProfileDto?> GetPatientProfileAsync(int patientId)
        {
            var patient = await _context.Patients
                .Include(p => p.User)
                .Include(p => p.BoneFractions)
                    .ThenInclude(b => b.Doctor)
                .Include(p => p.Inquiries)
                    .ThenInclude(i => i.Doctor)
                .FirstOrDefaultAsync(p => p.Id == patientId);

            if (patient == null) return null;

            return new PatientProfileDto
            {
                Id = patient.Id,
                FName = patient.FName,
                LName = patient.LName,
                Email = patient.User.Email,
                Gender = patient.Gender,
                ProfileImageUrl = patient.ProfileImageUrl,
                ConsultationHistory =
                patient.Inquiries
                    .Select(c => new PatientProfileConsultationsDto
                    {
                        ConsultationId = c.Id,
                        DoctorName ="Dr. " + c.Doctor.FName + " " + c.Doctor.LName,
                        Specialization = c.Doctor.Specialization,
                        ConsultationType = "inquiry",
                        ConsultationDate = c.CreatedOn
                    })
                    .Concat(
                    patient.BoneFractions
                        .Select(b => new PatientProfileConsultationsDto
                        {
                            ConsultationId = b.Id,
                            DoctorName = b.Doctor.FName + " " + b.Doctor.LName,
                            Specialization = b.Doctor.Specialization,
                            ConsultationType = "Bone Fracture", // أو enum
                            ConsultationDate = b.CreatedOn
                        })
                )
                .OrderByDescending(x => x.ConsultationDate)
                .ToList()
            };
        }
        // 3) تغيير حالة المريض (Active / Deleted)
        public async Task<bool> SetPatientStatusAsync(int patientId, bool isDeleted)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.Id == patientId);

            if (patient == null) return false;

            patient.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();
            return true;
        }
        
    }
}