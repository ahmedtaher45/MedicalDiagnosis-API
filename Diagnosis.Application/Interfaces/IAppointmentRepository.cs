using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using System.Linq;

namespace Diagnosis.Application.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<Appointment> AddAsync(Appointment appointment);
        Task<List<Appointment>> GetRecentAsync(int count);
        Task<List<Appointment>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<string, int>> GetAppointmentCountByMonthAsync(DateTime startDate);
    }
    }
