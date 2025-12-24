using Diagnosis.Application.DTOs;
using global::Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;


namespace Diagnosis.Application.UseCases.Dashboard.AdminDashboard
{


    public class GetTopDoctorsUseCase
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetTopDoctorsUseCase(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<TopDoctorsDto> ExecuteAsync()
        {
            var topDoctors = await _doctorRepository.GetTopDoctorsByAppointmentsAsync(7);

            var doctorData = topDoctors.Select(d => new ChartDataPointDto
            {
                Label = d.FName ?? "Unknown",
                Value = d.Appointments?.Count ?? 0
            }).ToList();

            return new TopDoctorsDto { Doctors = doctorData };
        }
    }
}
