using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.DoctorDashboard
{
    public class GetPatientsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientsUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PagedResultDTO<PatientListDTO>> GetPatientsAsync(PatientSearchDTO patientSearchDTO)
        {
            return await _unitOfWork.DoctorDashboardService.GetPatientsAsync(patientSearchDTO);
        }
    }
}
