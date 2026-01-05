using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.DoctorDashboard
{
    public class GetPatientProfileUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientProfileUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PatientProfileDetailsDTO> GetPatientProfileAsync(int patientId)
        {
            return await _unitOfWork.DoctorDashboardService.GetPatientProfileAsync(patientId);
        }
    }
}
