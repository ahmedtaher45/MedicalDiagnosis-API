namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class AppointmentsOverTimeDto
    {
        public List<ChartDataPointDto> CompletedAppointments { get; set; } = new();
        public List<ChartDataPointDto> PendingAppointments { get; set; } = new();
    }
}
