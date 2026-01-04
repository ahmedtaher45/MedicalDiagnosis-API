using Diagnosis.Application.DTOs.Treatment;

namespace Diagnosis.Application.Interfaces
{
    public interface ITreatmentRepository
    {
    
       
        Task<PatientTreatmentInfoDto> GetPatientTreatmentInfoAsync(string patientId);

     
        Task<PrescriptionResponseDto> CreatePrescriptionAsync(CreatePrescriptionDto dto);

        
        Task<TreatmentPlanDetailsDto> GetTreatmentPlanDetailsAsync(string treatmentPlanId);
        Task<TreatmentPlanResponseDto> CreateTreatmentPlanAsync(CreateTreatmentPlanDto dto);

        Task<byte[]> GenerateTreatmentPlanPdfAsync(string treatmentPlanId);

      
        Task<bool> PatientExistsAsync(string patientId);
        Task<bool> TreatmentPlanExistsAsync(string treatmentPlanId);
    }
}
