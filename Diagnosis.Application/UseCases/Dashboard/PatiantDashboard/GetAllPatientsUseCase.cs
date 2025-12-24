using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Dashboard.PatiantDashboard
{
    public class GetAllPatientsUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientDto>> ExecuteAsync()
        {
            var patients = await _patientRepository.GetAllAsync();

            return patients.Select(p => new PatientDto
            {
                Id = p.Id,
                UserId = p.UserId ?? string.Empty,
                FName = p.FName ?? string.Empty,
                LName = p.LName ?? string.Empty,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender ?? string.Empty,
                Address = p.Address ?? string.Empty,
                BloodType = p.BloodType ?? string.Empty,
                BirthDate = p.BirthDate,
                Allergies = p.Allergies ?? string.Empty,
                ProfileImageUrl = p.ProfileImageUrl ?? string.Empty,
                IsNewPatient = p.IsNewPatient,
                IsUrgent = p.IsUrgent,
                CreatedOn = p.CreatedOn,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }
    }

}
