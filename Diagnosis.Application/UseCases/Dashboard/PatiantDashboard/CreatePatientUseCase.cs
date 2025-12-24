using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Dashboard.PatiantDashboard
{
    public class CreatePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public CreatePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto> ExecuteAsync(CreatePatientDto dto)
        {
            var patient = new Diagnosis.Domain.Entites.Patient
            {
                UserId = dto.UserId,
                FName = dto.FName,
                LName = dto.LName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                Address = dto.Address,
                BloodType = dto.BloodType,
                BirthDate = dto.BirthDate,
                Allergies = dto.Allergies,
                ProfileImageUrl = dto.ProfileImageUrl,
                IsNewPatient = dto.IsNewPatient,
                IsUrgent = dto.IsUrgent,
                CreatedOn = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            var createdPatient = await _patientRepository.AddAsync(patient);

            return new PatientDto
            {
                Id = createdPatient.Id,
                UserId = createdPatient.UserId ?? string.Empty,
                FName = createdPatient.FName ?? string.Empty,
                LName = createdPatient.LName ?? string.Empty,
                DateOfBirth = createdPatient.DateOfBirth,
                Gender = createdPatient.Gender ?? string.Empty,
                Address = createdPatient.Address ?? string.Empty,
                BloodType = createdPatient.BloodType ?? string.Empty,
                BirthDate = createdPatient.BirthDate,
                Allergies = createdPatient.Allergies ?? string.Empty,
                ProfileImageUrl = createdPatient.ProfileImageUrl ?? string.Empty,
                IsNewPatient = createdPatient.IsNewPatient,
                IsUrgent = createdPatient.IsUrgent,
                CreatedOn = createdPatient.CreatedOn,
                UpdatedAt = createdPatient.UpdatedAt
            };
        }
    }

}
