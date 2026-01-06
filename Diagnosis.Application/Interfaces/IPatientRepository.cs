using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Domain.Entites;

namespace Diagnosis.Application.Interfaces
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task<Patient> UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<List<Patient>> SearchAsync(string searchTerm);
        Task<int> CountAsync();
        Task<int> CountNewPatientsAsync();
        Task<int> CountUrgentPatientsAsync();
        
    }
}