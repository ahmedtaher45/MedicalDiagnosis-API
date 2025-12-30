using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Infrastracture; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorManagement
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId)
        {
            var doctor = await _context.Set<Doctor>()
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null) return null;

            return new DoctorProfileDto
            {
                Id = doctor.Id,
                FullName = doctor.FName + " " + doctor.LName,
                Specialization = doctor.Specialization,
                IsActive = doctor.User.LockoutEnd == null,
                Email = doctor.User.Email,
                PhoneNumber = doctor.User.PhoneNumber,
                Gender = doctor.Gender,
                DateOfBirth = doctor.BirhDate,
                Address = doctor.Address,
                NationalId = doctor.NationalId,





            };

        }
        public async Task<IEnumerable<DoctorListItemDto>> GetDoctorsAsync(string? search,bool? isActive)
        {
            var query = _context.Set<Doctor>()
       .Include(d => d.User)
       .Include(d => d.Consultations)
       .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(d =>
                    (d.FName + " " + d.LName).Contains(search));
            }

            if (isActive.HasValue)
            {
                query = query.Where(d =>
                    (d.User.LockoutEnd == null) == isActive.Value);
            }

            return await query
                .Select(d => new DoctorListItemDto
                {
                    Id = d.Id,
                    FullName = d.FName + " " + d.LName,
                    //ExperienceYears = d.ExperienceYears,
                    Gender = d.Gender,
                    ConsultationsCount = d.Consultations.Count,
                    LastConsultationDate = d.Consultations
                        .OrderByDescending(c => c.Date)
                        .Select(c => c.Date)
                        .FirstOrDefault(),
                    IsActive = d.User.LockoutEnd == null
                })
                .ToListAsync();
        }
        public async Task<bool> SetDoctorStatusAsync(int doctorId, bool isActive)
        {
            var doctor = await _context.Set<Doctor>()
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null) return false;

            // Active = null, Inactive = تاريخ بعيد
            doctor.User.LockoutEnd = isActive ? null : DateTimeOffset.MaxValue;

            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> ResetPasswordAsync(int doctorId, string newPassword)
        {
            var doctor = await _context.Set<Doctor>()
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null) return false;

            
            return true;
        }





        //public IQueryable<Doctor> Query()
        //      => _context.Set<Doctor>().AsQueryable();

        //public async Task<List<Doctor>> GetAllAsync()
        //    => await _context.Set<Doctor>().ToListAsync();

        //public async Task<HashSet<Doctor>> GetAllPagedAsync(
        //    int pageSize,
        //    int pageNumber,
        //    Expression<Func<Doctor, object>> orderBy)
        //{
        //    var data = await _context.Set<Doctor>()
        //        .OrderBy(orderBy)
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return data.ToHashSet();
        //}

        //public async Task<List<Doctor>> GetManyAsync(
        //    Expression<Func<Doctor, bool>> predicate)
        //    => await _context.Set<Doctor>().Where(predicate).ToListAsync();

        //public async Task<Doctor?> GetAsync(
        //    Expression<Func<Doctor, bool>> predicate)
        //    => await _context.Set<Doctor>().FirstOrDefaultAsync(predicate);

        //public async Task<Doctor?> GetByIdAsync(object[] keyValues)
        //    => await _context.Set<Doctor>().FindAsync(keyValues);

        //public async Task AddAsync(Doctor entity)
        //{
        //    await _context.Set<Doctor>().AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public void Update(Doctor entity)
        //{
        //    _context.Set<Doctor>().Update(entity);
        //    _context.SaveChanges();
        //}

        //public async Task<bool> DeleteAsync(params object[] id)
        //{
        //    var entity = await _context.Set<Doctor>().FindAsync(id);
        //    if (entity is null) return false;

        //    _context.Set<Doctor>().Remove(entity);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}

    }
}


