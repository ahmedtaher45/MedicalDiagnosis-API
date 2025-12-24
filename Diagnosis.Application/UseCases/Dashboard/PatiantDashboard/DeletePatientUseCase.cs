using Diagnosis.Application.Interfaces;


namespace Diagnosis.Application.UseCases.Dashboard.PatiantDashboard
{
    public class DeletePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            return await _patientRepository.SoftDeleteAsync(id);
        }
    }
}
