
using Diagnosis.Application.DTOs;
using Diagnosis.Application.DTOs.Dashboard.AdminDashboard;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Identity;
using Microsoft.EntityFrameworkCore;


namespace Diagnosis.Infrastracture.Repositories
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardDto> GetDashboardDataAsync()
        {
            //var now = DateTime.Now;
            //var lastMonth = now.AddMonths(-1);

            //// Total Doctors
            //var totalDoctors = await _context.Set<Doctor>().CountAsync();
            //var lastMonthDoctors = await _context.Set<Doctor>()
            //    .Where(d => d.CreatedOn < lastMonth).CountAsync();
            //var doctorsChange = lastMonthDoctors > 0
            //    ? ((totalDoctors - lastMonthDoctors) / (double)lastMonthDoctors * 100)
            //    : 0;

            //// Active Doctors (اللي عملوا consultation في آخر 30 يوم)
            //var activeDoctors = await _context.Set<Inquiry>()
            //    .Where(c => c.CreatedOn >= now.AddDays(-30))
            //    .Select(c => c.DoctorId)
            //    .Distinct()
            //    .CountAsync();

            //// Total Patients
            //var totalPatients = await _context.Set<Patient>().CountAsync();
            //var lastMonthPatients = await _context.Set<Patient>()
            //    .Where(p => p.DateOfBirth < lastMonth).CountAsync();
            //var patientsChange = lastMonthPatients > 0
            //    ? ((totalPatients - lastMonthPatients) / (double)lastMonthPatients * 100)
            //    : 0;

            //// Diagnoses Over Time (آخر 6 شهور)
            //var diagnosesOverTime = await _context.Set<Inquiry>()
            //    .Where(c => c.CreatedOn >= now.AddMonths(-6))
            //    .GroupBy(c => new { c.Date.Year, c.Date.Month })
            //    .Select(g => new DiagnosisOverTimeDto
            //    {
            //        Month = g.Key.Month + "/" + g.Key.Year,
            //        DoctorDiagnoses = g.Count(),
            //        AiDiagnoses = g.Count(c => c.Type == ConsultationType.AIDiagnosis)
            //    })
            //    .OrderBy(d => d.Month)
            //    .ToListAsync();

            //// Top Doctors (آخر أسبوع)
            //var topDoctors = await _context.Set<Consultation>()
            //    .Where(c => c.Date >= now.AddDays(-7))
            //    .GroupBy(c => new { c.DoctorId, c.Doctor.FName, c.Doctor.LName })
            //    .Select(g => new TopDoctorDto
            //    {
            //        DoctorName = g.Key.FName + " " + g.Key.LName,
            //        DiagnosisCount = g.Count()
            //    })
            //    .OrderByDescending(d => d.DiagnosisCount)
            //    .Take(7)
            //    .ToListAsync();

            //// Recent Diagnoses
            //var recentDiagnoses = await _context.Set<Consultation>()
            //    .Include(c => c.Patient)
            //    .Include(c => c.Doctor)
            //    .OrderByDescending(c => c.Date)
            //    .Take(10)
            //    .Select(c => new RecentDiagnosisDto
            //    {
            //        PatientName = c.Patient.FName + " " + c.Patient.LName,
            //        DiagnosisType = c.DiagnosisName ?? "N/A",
            //        Date = c.Date,
            //        Time = c.Date.ToString("hh:mm tt"),
            //        Provider = c.Type == ConsultationType.AIDiagnosis ? "AI System" : "Dr." + c.Doctor.FName,
            //        Status = c.Status == ConsultationStatus.Accepted ? "confirmed" :
            //                c.Status == ConsultationStatus.Pending ? "pending" : "rejected"
            //    })
            //    .ToListAsync();

            return new AdminDashboardDto
            {
                //TotalDoctors = totalDoctors,
                //TotalDoctorsChange = $"+{doctorsChange:F1}% vs last month",
                //ActiveDoctors = activeDoctors,
                //ActiveDoctorsChange = $"+8% vs last month",
                //TotalPatients = totalPatients,
                //TotalPatientsChange = $"+{patientsChange:F1}% vs last month",
                //PeakUsageTime = "2:00 PM - 4:00 PM",
                //DiagnosesOverTime = diagnosesOverTime,
                //TopDoctors = topDoctors,
                //RecentDiagnoses = recentDiagnoses
            };
        }
    }
}