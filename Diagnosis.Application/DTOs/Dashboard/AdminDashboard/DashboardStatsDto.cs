namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
 
    public class DashboardStatsDto
    {
        public int TotalDoctors { get; set; }
        public int ActiveDoctors { get; set; }
        public int TotalPatients { get; set; }
        public int NewPatients { get; set; }
        public int UrgentPatients { get; set; }
        public string PeakUsageTime { get; set; } = string.Empty;
        public decimal DoctorGrowthPercentage { get; set; }
        public decimal ActiveDoctorGrowthPercentage { get; set; }
        public decimal PatientGrowthPercentage { get; set; }
    }
}
