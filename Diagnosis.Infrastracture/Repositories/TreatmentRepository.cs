using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.PdfService;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Entities;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.Infrastracture.Repositories
{
    public class TreatmentRepository : ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPdfService _pdfService;

        // Constructor واحد بس
        public TreatmentRepository(ApplicationDbContext context, IPdfService pdfService)
        {
            _context = context;
            _pdfService = pdfService;
        }

        public async Task<PatientTreatmentInfoDto> GetPatientTreatmentInfoAsync(string patientId)
        {
            var patient = await _context.Patients
                .Where(p => p.UserId == patientId)
                .Select(p => new PatientTreatmentInfoDto
                {
                    PatientId = p.UserId,
                    FullName = p.FName + " " + p.LName,
                    PatientIdentifier = p.UserId ?? "",
                    ProfileImageUrl = p.ProfileImageUrl
                })
                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<TreatmentPlanResponseDto> CreateTreatmentPlanAsync(CreateTreatmentPlanDto dto)
        {
            var treatmentPlan = new TreatmentPlan
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };

            _context.TreatmentPlans.Add(treatmentPlan);
            await _context.SaveChangesAsync();

            var response = await _context.TreatmentPlans
                .Where(t => t.Id == treatmentPlan.Id)
                .Include(t => t.Patient)
                .Include(t => t.Doctor)
                .Select(t => new TreatmentPlanResponseDto
                {
                    PatientId = t.PatientId,
                    PatientName = t.Patient.FName + " " + t.Patient.LName,
                    DoctorId = t.DoctorId,
                    DoctorName = t.Doctor.UserName,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                })
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<PrescriptionResponseDto> CreatePrescriptionAsync(CreatePrescriptionDto dto)
        {
            var prescription = new Prescription
            {
                PrescriptionId = Guid.NewGuid().ToString(),
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                TreatmentPlanId = dto.TreatmentPlanId,
                MedicationName = dto.MedicationName,
                Dosage = dto.Dosage,
                Frequency = dto.Frequency,
                Duration = dto.Duration,
                Instructions = dto.Instructions,
                Notes = dto.Notes,
                CreatedAt = DateTime.UtcNow
            };

            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();

            var response = await _context.Prescriptions
                .Where(p => p.PrescriptionId == prescription.PrescriptionId)
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .Select(p => new PrescriptionResponseDto
                {
                    Id = p.PrescriptionId,
                    PatientId = p.PatientId,
                    PatientName = p.Patient.FName + " " + p.Patient.LName,
                    PatientIdentifier = p.Patient.UserId ?? "",
                    DoctorId = p.DoctorId,
                    DoctorName = p.Doctor.UserName,
                    TreatmentPlanId = p.TreatmentPlanId,
                    MedicationName = p.MedicationName,
                    Dosage = p.Dosage,
                    Frequency = p.Frequency,
                    Duration = p.Duration,
                    Instructions = p.Instructions,
                    Notes = p.Notes,
                    CreatedAt = p.CreatedAt,
                    LastModifiedBy = p.Doctor.NormalizedUserName,
                })
                .FirstOrDefaultAsync();

            return response;
        }

        public async Task<TreatmentPlanDetailsDto> GetTreatmentPlanDetailsAsync(string treatmentPlanId)
        {
            var treatmentPlan = await _context.TreatmentPlans
                .Include(t => t.Patient)
                .Include(t => t.Doctor)
                .Where(t => t.PatientId == treatmentPlanId)
                .Select(t => new TreatmentPlanDetailsDto
                {
                    PatientId = t.PatientId,
                    PatientName = t.Patient.FName + " " + t.Patient.LName,
                    DoctorName = t.Doctor.UserName,
                    Duration = CalculateDuration(t.StartDate, t.EndDate),
                    Overview = t.Description ?? "",
                    KeyMedications = _context.Prescriptions
                        .Where(p => p.TreatmentPlanId == t.PatientId)
                        .Select(p => new KeyMedicationDto
                        {
                            MedicationName = p.MedicationName,
                            Dosage = p.Dosage
                        }).ToList(),
                    Hydration = new HydrationDto
                    {
                        Amount = "2.5 L water daily"
                    },
                    Restrictions = new RestrictionsDto
                    {
                        Description = "No Grapefruit"
                    },
                })
                .FirstOrDefaultAsync();

            return treatmentPlan;
        }

        public async Task<byte[]> GenerateTreatmentPlanPdfAsync(string treatmentPlanId)
        {
            return await _pdfService.GenerateTreatmentPlanPdfAsync(treatmentPlanId);
        }

        // Validation Methods
        public async Task<bool> PatientExistsAsync(string patientId)
        {
            return await _context.Patients.AnyAsync(p => p.UserId == patientId);
        }

        public async Task<bool> TreatmentPlanExistsAsync(string treatmentPlanId)
        {
            return await _context.TreatmentPlans.AnyAsync(t => t.PatientId == treatmentPlanId);
        }

        // Helper Method
        private string CalculateDuration(DateTime startDate, DateTime? endDate)
        {
            if (!endDate.HasValue)
                return "Ongoing";

            var duration = (endDate.Value - startDate).Days;
            var weeks = duration / 7;

            if (weeks == 0)
                return $"{duration} days";

            return $"{weeks} weeks";
        }
    }
}