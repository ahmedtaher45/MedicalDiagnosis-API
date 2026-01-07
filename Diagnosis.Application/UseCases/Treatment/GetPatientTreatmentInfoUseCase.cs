using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class GetPatientTreatmentInfoUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientTreatmentInfoUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PatientTreatmentInfoDto> ExecuteAsync(int patientId)
        {
            var patientExists = await _unitOfWork.Treatment.PatientExistsAsync(patientId);
            if (!patientExists)
                throw new KeyNotFoundException("Patient not found");

            return await _unitOfWork.Treatment.GetPatientTreatmentInfoAsync(patientId);
        }
    }
}