using System;
using System.Collections.Generic;

using global::Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using global::Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{
  public class CreateDoctorUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public CreateDoctorUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<DoctorDto> ExecuteAsync(CreateDoctorDto dto)
        {
            var doctor = new Diagnosis.Domain.Entites.Doctor
            {
                UserId = dto.UserId,
                FName = dto.FName,
                LName = dto.LName,
                Specialization = dto.Specialization,
                Bio = dto.Bio,
                ExperienceYears = dto.ExperienceYears,
                LicenseNumber = dto.LicenseNumber,
                ProfileImageUrl = dto.ProfileImageUrl,
                Rating = 0,
                CreatedOn = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            var createdDoctor = await _doctorRepository.AddAsync(doctor);

            return new DoctorDto
            {
                Id = createdDoctor.Id,
                UserId = createdDoctor.UserId ?? string.Empty,
                FName = createdDoctor.FName ?? string.Empty,
                LName = createdDoctor.LName ?? string.Empty,
                Specialization = createdDoctor.Specialization ?? string.Empty,
                Bio = createdDoctor.Bio ?? string.Empty,
                ExperienceYears = createdDoctor.ExperienceYears ?? 0,
                Rating = createdDoctor.Rating ?? 0,
                LicenseNumber = createdDoctor.LicenseNumber ?? string.Empty,
                ProfileImageUrl = createdDoctor.ProfileImageUrl ?? string.Empty,
                CreatedOn = createdDoctor.CreatedOn,
                UpdatedAt = createdDoctor.UpdatedAt,
                AppointmentsCount = 0
            };
        }
    }
}
