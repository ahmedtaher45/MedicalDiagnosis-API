using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;

namespace Diagnosis.Application.DTOs.Dashboard
{
    public class DoctorDashboardDto
    {
        //public DashboardSummaryDto? Summary { get; set; }
        //public List<RevenueBySessionTypeDto>? RevenuePerSessionType { get; set; }
        //public List<MonthlyEarningDto>? MonthlyEarnings { get; set; }
        //public List<RecentTransactionDto> ? RecentTransactions { get; set; }
        public List<PatientListDTO> PatientList { get; set; }
        public PatientProfileDetailsDTO PatientProfile {  get; set; }
     




    }
}
