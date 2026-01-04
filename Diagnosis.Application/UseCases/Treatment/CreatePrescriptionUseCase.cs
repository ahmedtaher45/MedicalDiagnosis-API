using Diagnosis.Application.DTOs.Treatment;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Treatment
{
    public class CreatePrescriptionUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePrescriptionUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PrescriptionResponseDto> ExecuteAsync(CreatePrescriptionDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.PatientId))
                throw new ArgumentException("PatientId is required");

            var patientExists = await _unitOfWork.Treatment
                .PatientExistsAsync(dto.PatientId);

            if (!patientExists)
                throw new KeyNotFoundException("Patient not found");

            if (!string.IsNullOrWhiteSpace(dto.TreatmentPlanId))
            {
                var treatmentPlanExists =
                    await _unitOfWork.Treatment
                        .TreatmentPlanExistsAsync(dto.TreatmentPlanId);

                if (!treatmentPlanExists)
                    throw new KeyNotFoundException("Treatment plan not found");
            }

            return await _unitOfWork.Treatment.CreatePrescriptionAsync(dto);
        }
    }
    }