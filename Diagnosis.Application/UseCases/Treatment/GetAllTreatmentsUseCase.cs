using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class GetAllTreatmentsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllTreatmentsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<TreatmentDTO>> ExecuteAsync()
        {
            var treatments = await _unitOfWork.Treatment.GetAllTreatmentsAsync();
            return treatments.Select(t => new TreatmentDTO
            {
                Id = t.Id,
                Name = t.Name,
                Dosage = t.Dosage,
                Method = t.Method,
                Frequency = t.Frequency,
                TotalDuration = t.TotalDuration,
                Alternatives = t.Alternatives,
                IsActive = t.IsActive,
                PatientId = t.PatientId,
                SideEffects = t.SideEffects.Select(se => new SideEffectDTO
                {
                    Id= se.Id,
                    Name = se.Name,
                    Description = se.Description,
                    IsSevere = se.IsSevere
                }).ToList(),
                PatientName = t.Patient != null ? $"{t.Patient.FName} {t.Patient.LName}" : null!
                //CreatedAt = t.CreatedAt
            });
        }
    }
}
