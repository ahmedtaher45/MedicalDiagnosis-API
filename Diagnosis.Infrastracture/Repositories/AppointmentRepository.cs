using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Diagnosis.Infrastructure.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Appointment> GetQueryable()
        {
            return _context.Appointments.AsQueryable();
        }
    }
}
