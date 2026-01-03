using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.PdfService;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.IO;

namespace Diagnosis.Infrastructure.Services
{
    public class PdfService : IPdfService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PdfService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> GenerateTreatmentPlanPdfAsync(string treatmentPlanId)
        {
            var treatmentPlan = await _unitOfWork.Treatment.GetTreatmentPlanDetailsAsync(treatmentPlanId);

            if (treatmentPlan == null)
                throw new KeyNotFoundException("Treatment plan not found");

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
                document.Add(new Paragraph($"Doctor: {treatmentPlan.DoctorName}", normalFont));
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
    }
}