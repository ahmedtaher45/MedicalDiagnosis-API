using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class GetActiveTreatmentsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetActiveTreatmentsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TreatmentDTO>> Execute()
        {
            var treatments = await _unitOfWork.Treatment.GetActiveTreatmentsAsync();

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
                PatientName = t.Patient != null ? $"{t.Patient.FName} {t.Patient.LName}" : null!
                // SideEffects تم حذفها
            });
        }
    }
}
