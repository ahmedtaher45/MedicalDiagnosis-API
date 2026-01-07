using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;

namespace Diagnosis.Application.Interfaces
{
    public interface IDoctorDashboardService
    {

        Task<DTOs.Dashboard.DoctorDashboardDto> GetDashboardAsync(int doctorId);
        Task<PagedResultDTO<PatientListDTO>> GetPatientsAsync(PatientSearchDTO patientSearchDTO);
        Task<PatientProfileDetailsDTO> GetPatientProfileAsync(int  patientId);

    } 
}
