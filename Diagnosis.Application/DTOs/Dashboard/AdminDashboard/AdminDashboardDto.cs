using System;
using System.Collections.Generic;


namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class AdminDashboardDto
    {
        public int TotalDoctors { get; set; }
        public string? TotalDoctorsChange { get; set; }
        public int ActiveDoctors { get; set; }
        public string? ActiveDoctorsChange { get; set; }
        public int TotalPatients { get; set; }
        public string? TotalPatientsChange { get; set; }
        public string? PeakUsageTime { get; set; }
        public List<DiagnosisOverTimeDto>? DiagnosesOverTime { get; set; }
        public List<TopDoctorDto>? TopDoctors { get; set; }
        public List<RecentDiagnosisDto>? RecentDiagnoses { get; set; }
    }
}
