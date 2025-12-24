using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Microsoft.EntityFrameworkCore;


namespace Diagnosis.Infrastracture.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted)
                .ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients
                .Where(p => !p.IsDeleted && p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            patient.CreatedOn = DateTime.UtcNow;
            patient.UpdatedAt = DateTime.UtcNow;
            patient.IsDeleted = false;

            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            patient.UpdatedAt = DateTime.UtcNow;
            patient.ModifiedOn = DateTime.UtcNow;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            patient.Delete();
            patient.ModifiedOn = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Patient>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllAsync();

            return await _context.Patients
                .Where(p => !p.IsDeleted &&
                           (p.FName.Contains(searchTerm) ||
                            p.LName.Contains(searchTerm) ||
                            p.BloodType.Contains(searchTerm)))
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Patients.CountAsync(p => !p.IsDeleted);
        }

        public async Task<int> CountNewPatientsAsync()
        {
            return await _context.Patients.CountAsync(p => !p.IsDeleted && p.IsNewPatient);
        }

        public async Task<int> CountUrgentPatientsAsync()
        {
            return await _context.Patients.CountAsync(p => !p.IsDeleted && p.IsUrgent);
        }
    
}
}
