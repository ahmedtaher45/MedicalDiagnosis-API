using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;

namespace Diagnosis.Application.UseCases.Dashboard
{
    public class GetDashboardStatsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public GetDashboardStatsUseCase(
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public async Task<DashboardStatsDto> ExecuteAsync()
        {
            var totalDoctors = await _doctorRepository.CountAsync();
            var activeDoctors = await _doctorRepository.CountActiveAsync();
            var totalPatients = await _patientRepository.CountAsync();
            var newPatients = await _patientRepository.CountNewPatientsAsync();
            var urgentPatients = await _patientRepository.CountUrgentPatientsAsync();

      
            var doctorGrowth = 2m;
            var activeDoctorGrowth = 11m;
            var patientGrowth = 15m;

            return new DashboardStatsDto
            {
                TotalDoctors = totalDoctors,
                ActiveDoctors = activeDoctors,
                TotalPatients = totalPatients,
                NewPatients = newPatients,
                UrgentPatients = urgentPatients,
                PeakUsageTime = "2:00 PM - 4:00 PM",
                DoctorGrowthPercentage = doctorGrowth,
                ActiveDoctorGrowthPercentage = activeDoctorGrowth,
                PatientGrowthPercentage = patientGrowth
            };
        }
    }
}