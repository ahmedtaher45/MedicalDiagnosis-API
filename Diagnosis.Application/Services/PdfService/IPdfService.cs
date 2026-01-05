namespace Diagnosis.Application.Services.PdfService
{
    public interface IPdfService
    {
        Task<byte[]> GenerateTreatmentPlanPdfAsync(string treatmentPlanId);
    }
}
