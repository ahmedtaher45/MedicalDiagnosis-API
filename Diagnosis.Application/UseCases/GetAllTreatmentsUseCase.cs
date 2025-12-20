using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases
{
    public class GetAllTreatmentsUseCase
    {
        private readonly ITreatmentRepository _treatmentRepository;
        public GetAllTreatmentsUseCase(ITreatmentRepository treatmentRepository)
        {
            _treatmentRepository = treatmentRepository;
        }
        public async Task<IEnumerable<TreatmentDTO>> ExecuteAsync()
        {
            var treatments = await _treatmentRepository.GetAllTreatmentsAsync();
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
                PatientName = t.Patient != null ? $"{t.Patient.FName} {t.Patient.LName}" : null,
                //CreatedAt = t.CreatedAt
            });
        }
        //private readonly ITreatmentRepository _treatmentRepository;
        //public GetAllTreatmentsUseCase(ITreatmentRepository treatmentRepository)
        //{
        //    _treatmentRepository = treatmentRepository;
        //}
        //public async Task<IEnumerable<TreatmentDTO>> ExecuteAsync()
        //{
        //    var treatments = await _treatmentRepository.GetAllAsync();
        //    return treatments.Select(t => new TreatmentDTO
        //    {
        //        Id = t.Id,
        //        Name = t.Name,
        //        Description = t.Description,
        //        Type = t.Type,
        //        Cost = t.Cost,
        //        Duration = t.DurationDays,
        //        Instructions = t.Instructions,
        //        IsActive = t.IsActive,
        //        //CreatedAt = t.CreatedAt
        //    });
        //}
    }
}
