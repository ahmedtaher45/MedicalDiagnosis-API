using Diagnosis.Application.DTOs.Dashboard.DoctorDashboard;

namespace Diagnosis.Application.Interfaces
{
    public interface IDoctorDashboardService
    {

        Task<DoctorDashboardDto> GetDashboardAsync(int doctorId);

    }
}
