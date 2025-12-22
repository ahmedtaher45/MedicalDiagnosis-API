/*using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnosis.Application.Services.DashboardService
{
    public class DoctorDashboardService : IDoctorDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorDashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorDashboardDto> GetDashboardAsync(int doctorId)
        {
            // 1️⃣ إجمالي المواعيد مع جلب الـ Payments
            var appointmentsQuery = _unitOfWork.Appointment.GetQueryable()
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Payments);

            var totalAppointments = await appointmentsQuery.CountAsync();

            // 2️⃣ إجمالي الإيرادات من جميع الـ Payments المرتبطة بالمواعيد
            var totalRevenue = await appointmentsQuery
                .SelectMany(a => a.Payments)
                .SumAsync(p => p.Amount);

            // 3️⃣ الأرباح الشهرية
            var monthlyEarnings = await appointmentsQuery
                .SelectMany(a => a.Payments, (appointment, payment) => new
                {
                    appointment.AppointmentDateTime,
                    payment.Amount
                })
                .GroupBy(x => new { x.AppointmentDateTime.Year, x.AppointmentDateTime.Month })
                .Select(g => new MonthlyEarningDto
                {
                    Month = g.Key.Month.ToString("D2") + "/" + g.Key.Year, // 01/2025 شكل مرتب
                    Earnings = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Month)
                .ToListAsync();

            // 4️⃣ تجميع الداشبورد
            return new DoctorDashboardDto
            {
                Summary = new DashboardSummaryDto
                {
                    TotalAppointments = totalAppointments,
                    TotalRevenue = totalRevenue
                },
                MonthlyEarnings = monthlyEarnings
            };
        }
    }
}
*/

using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Diagnosis.Application.Services.DashboardService
{
    public class DoctorDashboardService : IDoctorDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorDashboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorDashboardDto> GetDashboardAsync(int doctorId)
        {
            // نجيب كل الـ appointments الخاصة بالدكتور
            var appointmentsQuery = _unitOfWork.Appointment.GetQueryable()
                .Where(a => a.DoctorId == doctorId)
                .Include(a => a.Payments); // Include Payments

            // إجمالي المواعيد
            var totalAppointments = await appointmentsQuery.CountAsync();

            // إجمالي الإيرادات: نتأكد من Payments مش null
            var totalRevenue = await appointmentsQuery
                .SelectMany(a => a.Payments ?? new List<Domain.Entites.Payment>())
                .SumAsync(p => p.Amount);

            // الأرباح الشهرية
            var monthlyEarningsQuery = appointmentsQuery
                .SelectMany(a => a.Payments ?? new List<Domain.Entites.Payment>(), (appointment, payment) => new
                {
                    appointment.AppointmentDateTime,
                    Amount = payment.Amount
                })
                .GroupBy(x => new { x.AppointmentDateTime.Year, x.AppointmentDateTime.Month })
                .Select(g => new MonthlyEarningDto
                {
                    Month = g.Key.Month.ToString("D2") + "/" + g.Key.Year, // 01/2025
                    Earnings = g.Sum(x => x.Amount)
                })
                .OrderBy(x => x.Month);

            var monthlyEarnings = await monthlyEarningsQuery.ToListAsync();

            // تجميع الداشبورد
            var dashboard = new DoctorDashboardDto
            {
                Summary = new DashboardSummaryDto
                {
                    TotalAppointments = totalAppointments,
                    TotalRevenue = totalRevenue
                },
                MonthlyEarnings = monthlyEarnings
            };

            return dashboard;
        }
    }
}
