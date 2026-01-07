using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;

namespace Diagnosis.Application.Interfaces
{
    public interface IDoctorDashboardRepository
    {
        Task<DoctorDashboardDto> GetDoctorDashboardDataAsync(string userId);
    }
}
