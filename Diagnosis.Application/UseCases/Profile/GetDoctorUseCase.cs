using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class GetDoctorUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId)
        
        {
            return await _unitOfWork.Doctor.GetDoctorProfileAsync(doctorId);
        }
    }
}
