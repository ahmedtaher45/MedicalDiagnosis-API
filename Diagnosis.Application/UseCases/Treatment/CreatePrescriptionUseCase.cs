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

        public async Task<TreatmentPlanResponseDto> ExecuteAsync(CreatePrescriptionDto dto, string userId)
        {
            return await _unitOfWork.Treatment.CreatePrescriptionAsync(dto, userId);
        }
    }
    }