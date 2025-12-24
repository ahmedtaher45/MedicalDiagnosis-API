using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Dashboard.PatiantDashboard
{
    public class GetPatientByIdUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetPatientByIdUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<PatientDto?> ExecuteAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return null;

            return new PatientDto
            {
                Id = patient.Id,
                UserId = patient.UserId ?? string.Empty,
                FName = patient.FName ?? string.Empty,
                LName = patient.LName ?? string.Empty,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender ?? string.Empty,
                Address = patient.Address ?? string.Empty,
                BloodType = patient.BloodType ?? string.Empty,
                BirthDate = patient.BirthDate,
                Allergies = patient.Allergies ?? string.Empty,
                ProfileImageUrl = patient.ProfileImageUrl ?? string.Empty,
                IsNewPatient = patient.IsNewPatient,
                IsUrgent = patient.IsUrgent,
                CreatedOn = patient.CreatedOn,
                UpdatedAt = patient.UpdatedAt
            };
        }
    }
}
