using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Diagnosis.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly ApplicationDbContext _context;

    public DoctorRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Doctor>> GetAllAsync()
    {
        return await _context.Doctors
            .Where(d => !d.IsDeleted)
            .Include(d => d.Appointments)
            .ToListAsync();
    }

    public async Task<Doctor?> GetByIdAsync(int id)
    {
        return await _context.Doctors
            .Where(d => !d.IsDeleted && d.Id == id)
            .Include(d => d.Appointments)
            .FirstOrDefaultAsync();
    }

    public async Task<Doctor> AddAsync(Doctor doctor)
    {
        doctor.CreatedOn = DateTime.UtcNow;
        doctor.UpdatedAt = DateTime.UtcNow;
        doctor.IsDeleted = false;

        await _context.Doctors.AddAsync(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> UpdateAsync(Doctor doctor)
    {
        doctor.UpdatedAt = DateTime.UtcNow;
        doctor.ModifiedOn = DateTime.UtcNow;

        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return false;

        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var doctor = await _context.Doctors.FindAsync(id);
        if (doctor == null) return false;

        doctor.Delete();
        doctor.ModifiedOn = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Doctor>> SearchAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllAsync();

        return await _context.Doctors
            .Where(d => !d.IsDeleted &&
                       (d.FName.Contains(searchTerm) ||
                        d.LName.Contains(searchTerm) ||
                        d.Specialization.Contains(searchTerm) ||
                        d.LicenseNumber.Contains(searchTerm)))
            .Include(d => d.Appointments)
            .ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Doctors.CountAsync(d => !d.IsDeleted);
    }

    public async Task<int> CountActiveAsync()
    {
        // Active doctors = doctors with appointments in last 30 days
        var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);
        return await _context.Doctors
            .Where(d => !d.IsDeleted &&
                   d.Appointments.Any(a => a.AppointmentDateTime >= thirtyDaysAgo))
            .CountAsync();
    }

    public async Task<List<Doctor>> GetTopDoctorsByRatingAsync(int count)
    {
        return await _context.Doctors
            .Where(d => !d.IsDeleted)
            .OrderByDescending(d => d.Rating)
            .Take(count)
            .Include(d => d.Appointments)
            .ToListAsync();
    }

    public async Task<List<Doctor>> GetTopDoctorsByAppointmentsAsync(int count)
    {
        return await _context.Doctors
            .Where(d => !d.IsDeleted)
            .Include(d => d.Appointments)
            .OrderByDescending(d => d.Appointments.Count)
            .Take(count)
            .ToListAsync();
    }
}