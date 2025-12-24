using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{
    public class SearchDoctorsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public SearchDoctorsUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> ExecuteAsync(string searchTerm)
        {
            var doctors = await _doctorRepository.SearchAsync(searchTerm);

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
