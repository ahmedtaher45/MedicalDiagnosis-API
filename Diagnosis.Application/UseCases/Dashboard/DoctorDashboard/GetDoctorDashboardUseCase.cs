
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;

namespace Diagnosis.Application.UseCases.Dashboard.DoctorDashboard
{
        public class GetDoctorDashboardUseCase
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetDoctorDashboardUseCase(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<DoctorDashboardDto> ExecuteAsync(int doctorId)
            {
                return await _unitOfWork.DoctorDashboard.GetDoctorDashboardDataAsync(doctorId);
            }
        }
    }
