using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;



namespace Diagnosis.Application.UseCases.Dashboard.AdminDashboard
{

    public class GetAppointmentsOverTimeUseCase
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public GetAppointmentsOverTimeUseCase(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentsOverTimeDto> ExecuteAsync()
        {
            var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);
            var appointments = await _appointmentRepository.GetByDateRangeAsync(sixMonthsAgo, DateTime.UtcNow);

            var months = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            var completedData = new List<ChartDataPointDto>();
            var pendingData = new List<ChartDataPointDto>();

            for (int i = 5; i >= 0; i--)
            {
                var date = DateTime.UtcNow.AddMonths(-i);
                var monthName = months[date.Month - 1];

                var monthAppointments = appointments.Where(a =>
                    a.AppointmentDateTime.Year == date.Year &&
                    a.AppointmentDateTime.Month == date.Month).ToList();

                var completedCount = monthAppointments.Count(a => a.Status == "Completed");
                var pendingCount = monthAppointments.Count(a => a.Status == "Pending");

                completedData.Add(new ChartDataPointDto { Label = monthName, Value = completedCount });
                pendingData.Add(new ChartDataPointDto { Label = monthName, Value = pendingCount });
            }

            return new AppointmentsOverTimeDto
            {
                CompletedAppointments = completedData,
                PendingAppointments = pendingData
            };
        }
    }
}
