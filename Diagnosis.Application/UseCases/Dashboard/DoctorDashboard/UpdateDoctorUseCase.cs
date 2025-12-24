using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;


namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{
    public class UpdateDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<bool> ExecuteAsync(int id, UpdateDoctorDto dto)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                return false;

            doctor.FName = dto.FName;
            doctor.LName = dto.LName;
            doctor.Specialization = dto.Specialization;
            doctor.Bio = dto.Bio;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.LicenseNumber = dto.LicenseNumber;
            doctor.ProfileImageUrl = dto.ProfileImageUrl;
            doctor.UpdatedAt = DateTime.UtcNow;
            doctor.ModifiedOn = DateTime.UtcNow;

            await _doctorRepository.UpdateAsync(doctor);
            return true;
        }
    }
}