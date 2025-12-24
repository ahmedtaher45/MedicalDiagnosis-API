using Diagnosis.Application.DTOs;
using global::Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using global::Diagnosis.Application.Interfaces;



namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{
   
    public class GetDoctorByIdUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorByIdUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDto?> ExecuteAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null)
                return null;

            return new DoctorDto
            {
                Id = doctor.Id,
                UserId = doctor.UserId ?? string.Empty,
                FName = doctor.FName ?? string.Empty,
                LName = doctor.LName ?? string.Empty,
                Specialization = doctor.Specialization ?? string.Empty,
                Bio = doctor.Bio ?? string.Empty,
                ExperienceYears = doctor.ExperienceYears ?? 0,
                Rating = doctor.Rating ?? 0,
                LicenseNumber = doctor.LicenseNumber ?? string.Empty,
                ProfileImageUrl = doctor.ProfileImageUrl ?? string.Empty,
                CreatedOn = doctor.CreatedOn,
                UpdatedAt = doctor.UpdatedAt,
                AppointmentsCount = doctor.Appointments?.Count ?? 0
            };
        }
    }
}
