using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class GetPatientUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetPatientUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientProfileDto?> GetPatientProfileAsync(int patientId)
        {
            return await _unitOfWork.Patient.GetPatientProfileAsync(patientId);
        }
    }
}
