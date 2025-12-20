using Diagnosis.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface ITreatmentRepository: IRepository<Treatment>
    {
        Task<IEnumerable<Treatment>> GetActiveTreatmentsAsync();
        Task<IEnumerable<Treatment>> GetAllTreatmentsAsync();
        Task<Treatment> GetTreatmentByIdAsync(int id);
        Task<IEnumerable<Treatment>> GetTreatmentsByPatientIdAsync(int patientId);
    }
}
