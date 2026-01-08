using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.Infrastracture.Repositories
{
    public class TreatmentRepository : Repository<Inquiry> ,ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;

        public TreatmentRepository(ApplicationDbContext context, IFileService fileService) : base(context)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<PatientTreatmentInfoDto> GetPatientTreatmentInfoAsync(int patientId)
        {
            var patient = await _context.Patients
                .Where(p => p.Id == patientId)
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

        public async Task<TreatmentPlanResponseDto> CreateTreatmentPlanAsync(TreatmentPlanDetailsDto dto, string userId)
        {
            if (dto == null)
                throw new KeyNotFoundException("Treatment plan data is null");

            var doctor = await _context.Doctors
                .Include(x => x.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var pdfBytes = GenerateTreatmentPlanPdfAsync(dto, doctor!);

            var pdfPath = await _fileService.SaveBytesAsync(
                pdfBytes,
                $"treatment_plan_{dto.PatientId}_{DateTime.UtcNow:yyyyMMdd}",
                ".pdf" 
            );

            var inquiy = await _context.Inquiries.FirstOrDefaultAsync(x => x.DoctorId == doctor.Id && x.PatientId == dto.PatientId);

            if (inquiy == null)
            {
                return new TreatmentPlanResponseDto
                {
                    Success = false,
                    Message = "Not inquiry found for this patient"
                };
            }
            inquiy.TreatmentUrl = pdfPath;
             _context.Inquiries.Update(inquiy);
            await _context.SaveChangesAsync();

            return new TreatmentPlanResponseDto
            {
                Success = true,
                Message = "Treatment plan file saved successfully"
            };
        }

        public async Task<TreatmentPlanResponseDto> CreatePrescriptionAsync(CreatePrescriptionDto dto, string userId)
        {
            if (dto == null)
                throw new KeyNotFoundException("Treatment plan data is null");

            var doctor = await _context.Doctors
                .Include(x => x.User)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            var pdfBytes = GeneratePrescriptionPdfAsync(dto, doctor!);

            var pdfPath = await _fileService.SaveBytesAsync(
                     pdfBytes,
                     $"treatment_plan_{dto.PatientId}_{DateTime.UtcNow:yyyyMMdd}",
                     ".pdf"
                 );

            var inquiy = await _context.Inquiries.FirstOrDefaultAsync(x => x.DoctorId == doctor.Id && x.PatientId == dto.PatientId);

            if (inquiy == null)
            {
                return new TreatmentPlanResponseDto
                {
                    Success = false,
                    Message = "Not inquiry found for this patient"
                };
            }
            inquiy.PrescriptionUrl = pdfPath;
            _context.Inquiries.Update(inquiy);
            await _context.SaveChangesAsync();

            return new TreatmentPlanResponseDto
            {
                Success = true,
                Message = "Prescription file saved successfully"
            };
        }


        public byte[] GenerateTreatmentPlanPdfAsync(TreatmentPlanDetailsDto treatmentPlan, Doctor doctor)
        {

            using (var memoryStream = new MemoryStream())
            {
                // Create document
                var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 25, 25);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Title
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var title = new Paragraph("Treatment Plan", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                // Patient Info
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                document.Add(new Paragraph($"Patient: {treatmentPlan.PatientName}", headerFont));
                document.Add(new Paragraph($"Doctor: {doctor.User.UserName}", normalFont));
                document.Add(new Paragraph($"Duration: {treatmentPlan.Duration}", normalFont));
                document.Add(new Paragraph($"Date: {treatmentPlan.CreatedAt:dd/MM/yyyy}", normalFont));
                document.Add(new Paragraph("\n"));

                // Overview Section
                document.Add(new Paragraph("Overview", headerFont));
                document.Add(new Paragraph(treatmentPlan.Overview, normalFont));
                document.Add(new Paragraph("\n"));

                // Key Medications
                document.Add(new Paragraph("Key Medications", headerFont));
                foreach (var medication in treatmentPlan.KeyMedications)
                {
                    document.Add(new Paragraph($"• {medication.MedicationName} - {medication.Dosage}", normalFont));
                }
                document.Add(new Paragraph("\n"));

                // Hydration
                if (treatmentPlan.Hydration != null)
                {
                    document.Add(new Paragraph("Hydration", headerFont));
                    document.Add(new Paragraph(treatmentPlan.Hydration.Amount, normalFont));
                    document.Add(new Paragraph("\n"));
                }

                // Restrictions
                if (treatmentPlan.Restrictions != null)
                {
                    document.Add(new Paragraph("Restrictions", headerFont));
                    document.Add(new Paragraph(treatmentPlan.Restrictions.Description, normalFont));
                }

                document.Close();
                writer.Close();

                return memoryStream.ToArray();
            }
        }

        public byte[] GeneratePrescriptionPdfAsync(
            CreatePrescriptionDto prescription,
            Doctor doctor)
        {
            using (var memoryStream = new MemoryStream())
            {
                // Create document
                var document = new iTextSharp.text.Document(PageSize.A4, 50, 50, 25, 25);
                var writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                // Fonts
                var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // Title
                var title = new Paragraph("Prescription", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                document.Add(title);

                // Patient Info
                document.Add(new Paragraph($"Patient: {prescription.PatientName}", headerFont));
                document.Add(new Paragraph($"Patient ID: {prescription.PatientId}", normalFont));
                document.Add(new Paragraph($"Doctor: {doctor.User.UserName}", normalFont));
                document.Add(new Paragraph($"Date: {prescription.CreatedAt:dd/MM/yyyy}", normalFont));
                document.Add(new Paragraph("\n"));

                // Medication Section
                document.Add(new Paragraph("Medication Details", headerFont));
                document.Add(new Paragraph($"Medication: {prescription.MedicationName}", normalFont));
                document.Add(new Paragraph($"Dosage: {prescription.Dosage}", normalFont));
                document.Add(new Paragraph($"Frequency: {prescription.Frequency}", normalFont));
                document.Add(new Paragraph($"Duration: {prescription.Duration}", normalFont));
                document.Add(new Paragraph("\n"));

                // Instructions
                if (!string.IsNullOrWhiteSpace(prescription.Instructions))
                {
                    document.Add(new Paragraph("Instructions", headerFont));
                    document.Add(new Paragraph(prescription.Instructions, normalFont));
                    document.Add(new Paragraph("\n"));
                }

                // Notes
                if (!string.IsNullOrWhiteSpace(prescription.Notes))
                {
                    document.Add(new Paragraph("Notes", headerFont));
                    document.Add(new Paragraph(prescription.Notes, normalFont));
                }

                // Footer
                document.Add(new Paragraph("\n\n"));
                document.Add(new Paragraph(
                    $"Last modified by Dr. {doctor.User.UserName}",
                    FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 9)
                ));

                document.Close();
                writer.Close();

                return memoryStream.ToArray();
            }
        }

        // Validation Methods
        public async Task<bool> PatientExistsAsync(int patientId)
        {
            return await _context.Patients.AnyAsync(p => p.Id == patientId);
        }



    }
}