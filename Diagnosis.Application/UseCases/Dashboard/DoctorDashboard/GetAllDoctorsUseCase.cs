using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;


namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{

    public class GetAllDoctorsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAllDoctorsUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> ExecuteAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();

            return doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                UserId = d.UserId ?? string.Empty,
                FName = d.FName ?? string.Empty,
                LName = d.LName ?? string.Empty,
                Specialization = d.Specialization ?? string.Empty,
                Bio = d.Bio ?? string.Empty,
                ExperienceYears = d.ExperienceYears ?? 0,
                Rating = d.Rating ?? 0,
                LicenseNumber = d.LicenseNumber ?? string.Empty,
                ProfileImageUrl = d.ProfileImageUrl ?? string.Empty,
                CreatedOn = d.CreatedOn,
                UpdatedAt = d.UpdatedAt,
                AppointmentsCount = d.Appointments?.Count ?? 0
            }).ToList();
        }
    }
}