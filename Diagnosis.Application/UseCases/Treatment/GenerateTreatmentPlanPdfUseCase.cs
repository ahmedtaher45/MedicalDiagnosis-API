using Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.TreatmentManagement
{
    public class GenerateTreatmentPlanPdfUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenerateTreatmentPlanPdfUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> ExecuteAsync(string treatmentPlanId)
        {
            if (string.IsNullOrEmpty(treatmentPlanId))
                throw new ArgumentException("Treatment plan ID is required");

            var treatmentPlanExists = await _unitOfWork.Treatment.TreatmentPlanExistsAsync(treatmentPlanId);
            if (!treatmentPlanExists)
                throw new KeyNotFoundException("Treatment plan not found");

            return await _unitOfWork.Treatment.GenerateTreatmentPlanPdfAsync(treatmentPlanId);
        }
    }
}