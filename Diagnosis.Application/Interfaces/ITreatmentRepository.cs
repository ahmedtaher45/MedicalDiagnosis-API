using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;

namespace Diagnosis.Application.Interfaces
{
    public interface ITreatmentRepository: IRepository<Inquiry>
    {
    
       
        Task<PatientTreatmentInfoDto> GetPatientTreatmentInfoAsync(int patientId);

     
        Task<TreatmentPlanResponseDto> CreatePrescriptionAsync(CreatePrescriptionDto dto, string userId);

        
        Task<TreatmentPlanResponseDto> CreateTreatmentPlanAsync(TreatmentPlanDetailsDto dto, string userId);

        byte[] GenerateTreatmentPlanPdfAsync(TreatmentPlanDetailsDto treatmentPlan, Doctor doctor);
        byte[] GeneratePrescriptionPdfAsync(
                    CreatePrescriptionDto prescription,
                    Doctor doctor);


        Task<bool> PatientExistsAsync(int patientId);
    }
}
