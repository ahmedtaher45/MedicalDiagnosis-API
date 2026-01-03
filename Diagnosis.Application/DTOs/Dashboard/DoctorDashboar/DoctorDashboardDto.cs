
namespace Diagnosis.Application.DTOs.Dashboard.DoctorDashboar
{
    public class DoctorDashboardDto
    {
        public int TotalConsultations { get; set; }
        public int TotalTreatmentPlans { get; set; }
        public List<PatientStatDto>? NewVsReturningPatients { get; set; }
        public List<RatingStatDto>? RatingStats { get; set; }
        public List<EarningStatDto>? EarningsStats { get; set; }
        public List<CommonDiagnosisDto>? CommonDiagnoses { get; set; }
    }
}