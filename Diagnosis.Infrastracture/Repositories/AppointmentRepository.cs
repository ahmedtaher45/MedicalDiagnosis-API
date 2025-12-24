using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Diagnosis.Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Appointment> AddAsync(Appointment appointment)
        {
            appointment.CreatedOn = DateTime.UtcNow;
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<List<Appointment>> GetRecentAsync(int count)
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .OrderByDescending(a => a.AppointmentDateTime)
                .Take(count)
                .ToListAsync();
        }

        public async Task<List<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
                .Where(a => a.AppointmentDateTime >= startDate && a.AppointmentDateTime <= endDate)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetAppointmentCountByMonthAsync(DateTime startDate)
        {
            var appointments = await _context.Appointments
                .Where(a => a.AppointmentDateTime >= startDate)
                .GroupBy(a => new { a.AppointmentDateTime.Year, a.AppointmentDateTime.Month })
                .Select(g => new
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    Count = g.Count()
                })
                .ToListAsync();

            var result = new Dictionary<string, int>();
            foreach (var item in appointments)
            {
                var key = $"{item.Year}-{item.Month:D2}";
                result[key] = item.Count;
            }

            return result;
        }

        public async Task<int> CountByStatusAsync(string status)
        {
            return await _context.Appointments
                .CountAsync(a => a.Status == status);
        }
    }
}
