

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class RecentDiagnosisDto
    {
        public string? PatientName { get; set; }
        public string? DiagnosisType { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Provider { get; set; }
        public string? Status { get; set; }
    }
}
