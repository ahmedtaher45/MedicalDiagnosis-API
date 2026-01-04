using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class GetTreatmentPlanDetailsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTreatmentPlanDetailsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TreatmentPlanDetailsDto> ExecuteAsync(string treatmentPlanId)
        {
            if (string.IsNullOrEmpty(treatmentPlanId))
                throw new ArgumentException("Treatment plan ID is required");

            var treatmentPlanExists = await _unitOfWork.Treatment.TreatmentPlanExistsAsync(treatmentPlanId);
            if (!treatmentPlanExists)
                throw new KeyNotFoundException("Treatment plan not found");

            return await _unitOfWork.Treatment.GetTreatmentPlanDetailsAsync(treatmentPlanId);
        }
    }
}