using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;



namespace Diagnosis.Application.UseCases.Dashboard.AdminDashboard
{

        public class GetAdminDashboardUseCase
        {
            private readonly IUnitOfWork _unitOfWork;

            public GetAdminDashboardUseCase(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<AdminDashboardDto> ExecuteAsync()
            {
                return await _unitOfWork.AdminDashboard.GetDashboardDataAsync();
            }
        }
    }