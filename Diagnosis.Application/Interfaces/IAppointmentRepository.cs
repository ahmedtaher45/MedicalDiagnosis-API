using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using System.Linq;

namespace Diagnosis.Application.Interfaces
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IQueryable<Appointment> GetQueryable();
    }
}
