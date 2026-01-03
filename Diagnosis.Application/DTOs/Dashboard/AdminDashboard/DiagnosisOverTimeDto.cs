

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class DiagnosisOverTimeDto
    {
        public string? Month { get; set; }
        public int DoctorDiagnoses { get; set; }
        public int AiDiagnoses { get; set; }
    }
}
