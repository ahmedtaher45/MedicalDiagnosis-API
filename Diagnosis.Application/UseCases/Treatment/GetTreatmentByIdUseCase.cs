using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class GetTreatmentByIdUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTreatmentByIdUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TreatmentDTO> ExecuteAsync(int id)
        {
            var treatment = await _unitOfWork.Treatment.GetByIdAsync(new object[] { id });
            if (treatment == null)
            {
                throw new Exception("Treatment not found");
            }

            return new TreatmentDTO
            {
                Id = treatment.Id,
                Name = treatment.Name,
                Dosage = treatment.Dosage,
                Method = treatment.Method,
                Frequency = treatment.Frequency,
                TotalDuration = treatment.TotalDuration,
                Alternatives = treatment.Alternatives,
                IsActive = treatment.IsActive,
                PatientId = treatment.PatientId,
                SideEffects = treatment.SideEffects.Select(se => new SideEffectDTO
                {
                    Id = se.Id,
                    Name = se.Name,
                    Description = se.Description,
                    IsSevere = se.IsSevere
                }).ToList(),
                PatientName = treatment.Patient != null ? $"{treatment.Patient.FName} {treatment.Patient.LName}" : null!

                //CreatedAt = treatment.CreatedAt
            };
        }  }
}
