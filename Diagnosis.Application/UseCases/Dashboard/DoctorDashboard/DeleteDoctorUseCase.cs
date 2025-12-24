using Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{

    public class DeleteDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            return await _doctorRepository.SoftDeleteAsync(id);
        }
    }
}
