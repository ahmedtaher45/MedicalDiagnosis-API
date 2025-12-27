using Diagnosis.Application.DTOs;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;

namespace Diagnosis.Application.Interfaces
{
    public interface IDoctorDashboardRepository
    {
        Task<DoctorDashboardDto> GetDoctorDashboardDataAsync(int doctorId);
    }
}