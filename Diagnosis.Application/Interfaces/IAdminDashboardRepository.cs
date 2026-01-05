using Diagnosis.Application.DTOs;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;


namespace Diagnosis.Application.Interfaces
{
    public interface IAdminDashboardRepository
    {
        Task<AdminDashboardDto> GetDashboardDataAsync();
    }
}
