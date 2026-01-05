using Diagnosis.Domain.Entites;

namespace Diagnosis.Application.Interfaces;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetAllAsync();
    Task<Doctor?> GetByIdAsync(int id);
    Task<Doctor> AddAsync(Doctor doctor);
    Task<Doctor> UpdateAsync(Doctor doctor);
    Task<bool> DeleteAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<List<Doctor>> SearchAsync(string searchTerm);
    Task<int> CountAsync();
    Task<int> CountActiveAsync();
    Task<List<Doctor>> GetTopDoctorsByRatingAsync(int count);
    Task<List<Doctor>> GetTopDoctorsByAppointmentsAsync(int count);
}