using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Dashboard.PatiantDashboard
{
    public class UpdatePatientUseCase
    {
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientUseCase(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<bool> ExecuteAsync(int id, CreatePatientDto dto)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return false;

            patient.FName = dto.FName;
            patient.LName = dto.LName;
            patient.DateOfBirth = dto.DateOfBirth;
            patient.Gender = dto.Gender;
            patient.Address = dto.Address;
            patient.BloodType = dto.BloodType;
            patient.BirthDate = dto.BirthDate;
            patient.Allergies = dto.Allergies;
            patient.ProfileImageUrl = dto.ProfileImageUrl;
            patient.IsNewPatient = dto.IsNewPatient;
            patient.IsUrgent = dto.IsUrgent;
            patient.UpdatedAt = DateTime.UtcNow;
            patient.ModifiedOn = DateTime.UtcNow;

            await _patientRepository.UpdateAsync(patient);
            return true;
        }
    }

 
}
