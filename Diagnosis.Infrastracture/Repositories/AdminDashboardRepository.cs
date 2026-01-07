
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
            var now = DateTime.Now;
            var lastMonth = now.AddMonths(-1);

            // Total Doctors
            var totalDoctors = await _context.Set<Doctor>().CountAsync();
            var lastMonthDoctors = await _context.Set<Doctor>()
               .Where(d => d.CreatedOn < lastMonth).CountAsync();
            var doctorsChange = lastMonthDoctors > 0
               ? ((totalDoctors - lastMonthDoctors) / (double)lastMonthDoctors * 100)
               : 0;

            // Active Doctors (اللي عملوا consultation في آخر 30 يوم)
            var activeDoctors = await _context.Set<Inquiry>()
               .Where(c => c.CreatedOn >= now.AddDays(-30))
               .Select(c => c.DoctorId)
               .Distinct()
               .CountAsync();

            // Total Patients
            var totalPatients = await _context.Set<Patient>().CountAsync();
            var lastMonthPatients = await _context.Set<Patient>()
               .Where(p => p.DateOfBirth < lastMonth).CountAsync();
            var patientsChange = lastMonthPatients > 0
               ? ((totalPatients - lastMonthPatients) / (double)lastMonthPatients * 100)
               : 0;

            // Diagnoses Over Time (آخر 6 شهور)
             var diagnosesOverTime = await _context.Set<Inquiry>()
                .Where(c => c.CreatedOn.HasValue &&
                            c.CreatedOn.Value >= now.AddMonths(-6))
                .GroupBy(c => new
                {
                    Year = c.CreatedOn.Value.Year,
                    Month = c.CreatedOn.Value.Month
                })
                .OrderBy(g => g.Key.Year)
                .ThenBy(g => g.Key.Month)
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Count()
                })
                .ToListAsync();

            var diagnosesOverTimeDto = diagnosesOverTime
                .Select(g => new DiagnosisOverTimeDto
                {
                    Month = $"{g.Month:D2}/{g.Year}",
                    DoctorDiagnoses = g.Count,
                    AiDiagnoses = g.Count
                })
                .ToList();

            // Top Doctors (آخر أسبوع)
            var topDoctors = await _context.Set<Inquiry>()
               .Where(c => c.CreatedOn >= now.AddDays(-7))
               .GroupBy(c => new { c.DoctorId, c.Doctor.FName, c.Doctor.LName })
               .Select(g => new TopDoctorDto
               {
                   DoctorName = g.Key.FName + " " + g.Key.LName,
                   DiagnosisCount = g.Count()
               })
               .OrderByDescending(d => d.DiagnosisCount)
               .Take(7)
               .ToListAsync();

            // Recent Diagnoses
            var recentDiagnoses = await _context.Set<Inquiry>()
               .Include(c => c.Patient)
               .Include(c => c.Doctor)
               .OrderByDescending(c => c.CreatedOn)
               .Take(10)
               .Select(c => new RecentDiagnosisDto
               {
                   PatientName = c.Patient.FName + " " + c.Patient.LName,
                   Date = c.CreatedOn,
                   Time = c.CreatedOn.Value.ToString("hh:mm tt"),
                   Provider =  "Dr." + c.Doctor.FName,
                   Status = c.Status == ConsultationStatus.Accepted ? "confirmed" :
                           c.Status == ConsultationStatus.Pending ? "pending" : "rejected"
               })
               .ToListAsync();

            return new AdminDashboardDto
            {
                TotalDoctors = totalDoctors,
                TotalDoctorsChange = $"+{doctorsChange:F1}% vs last month",
                ActiveDoctors = activeDoctors,
                ActiveDoctorsChange = $"+8% vs last month",
                TotalPatients = totalPatients,
                TotalPatientsChange = $"+{patientsChange:F1}% vs last month",
                PeakUsageTime = "2:00 PM - 4:00 PM",
                DiagnosesOverTime = diagnosesOverTimeDto,
                TopDoctors = topDoctors,
                RecentDiagnoses = recentDiagnoses
            };
        }
    }
}