using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Entities;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.Infrastracture.Repositories
{
    public class DoctorDashboardRepository : IDoctorDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public DoctorDashboardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DoctorDashboardDto> GetDoctorDashboardDataAsync(int doctorId)
        {
            var today = DateTime.Today;
            var last7Days = today.AddDays(-7);

   
            var totalConsultations = await _context.Set<Consultation>()
                .Where(c => c.DoctorId == doctorId)
                .CountAsync();

            var totalTreatmentPlans = await _context.Set<Prescription>()
                .Where(p => p.Id == doctorId)
                .CountAsync();
         

            var patientStats = new List<PatientStatDto>();
            for (int i = 6; i >= 0; i--)
            {
                var date = today.AddDays(-i);
                var dayName = date.DayOfWeek.ToString().Substring(0, 3);

                var consultationsOnDay = await _context.Set<Consultation>()
                    .Where(c => c.DoctorId == doctorId && c.Date.Date == date)
                    .ToListAsync();

                var allPatientIds = consultationsOnDay.Select(c => c.PatientId).Distinct();
                var newPatientIds = new List<int>();

                foreach (var patientId in allPatientIds)
                {
                    var firstVisit = await _context.Set<Consultation>()
                        .Where(c => c.DoctorId == doctorId && c.PatientId == patientId)
                        .OrderBy(c => c.Date)
                        .FirstOrDefaultAsync();

                    if (firstVisit?.Date.Date == date)
                        newPatientIds.Add(patientId);
                }

                var newPatients = newPatientIds.Count;
                var returningPatients = allPatientIds.Count() - newPatients;

                patientStats.Add(new PatientStatDto
                {
                    Day = dayName,
                    NewPatients = newPatients,
                    ReturningPatients = returningPatients
                });
            }

            var ratingStats = new List<RatingStatDto>();
            for (int i = 6; i >= 0; i--)
            {
                var date = today.AddDays(-i);
                var dayName = date.DayOfWeek.ToString().Substring(0, 3);

                var avgRating = await _context.Set<Consultation>()
                    .Where(c => c.DoctorId == doctorId &&
                               c.Date.Date == date &&
                               c.Rating.HasValue)
                    .AverageAsync(c => (decimal?)c.Rating) ?? 0;

                ratingStats.Add(new RatingStatDto
                {
                    Day = dayName,
                    AverageRating = avgRating
                });
            }

            var earningsStats = new List<EarningStatDto>();
            for (int i = 6; i >= 0; i--)
            {
                var date = today.AddDays(-i);
                var dayName = date.DayOfWeek.ToString().Substring(0, 3);

              
                var consultationEarnings = await _context.Set<Consultation>()
                    .Where(c => c.DoctorId == doctorId &&
                               c.Date.Date == date &&
                               c.Price.HasValue)
                    .SumAsync(c => (decimal?)c.Price) ?? 0;

                
                var paymentEarnings = await _context.Set<Payment>()
                    .Where(p => p.DoctorId == doctorId &&
                               p.PaymentDate.Date == date)
                    .SumAsync(p => (decimal?)p.Amount) ?? 0;

                
                var totalEarnings = consultationEarnings + paymentEarnings;

                earningsStats.Add(new EarningStatDto
                {
                    Day = dayName,
                    Salary = totalEarnings
                });
            }

            // Common Diagnoses 
            var commonDiagnoses = await _context.Set<Consultation>()
                .Where(c => c.DoctorId == doctorId &&
                           c.Date >= today.AddMonths(-1) &&
                           !string.IsNullOrEmpty(c.DiagnosisName))
                .GroupBy(c => c.DiagnosisName)
                .Select(g => new CommonDiagnosisDto
                {
                    DiagnosisName = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(d => d.Count)
                .Take(8)
                .ToListAsync();

            return new DoctorDashboardDto
            {
                TotalConsultations = totalConsultations,
                TotalTreatmentPlans = totalTreatmentPlans,
                NewVsReturningPatients = patientStats,
                RatingStats = ratingStats,
                EarningsStats = earningsStats,
                CommonDiagnoses = commonDiagnoses
            };
        }

        public Task<DoctorDashboardDto> GetDoctorDashboardDataAsync(string doctorId)
        {
            throw new NotImplementedException();
        }
    }
}