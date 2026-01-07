using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture; // <-- Ensure this matches the actual namespace where AppDbContext is defined
using Diagnosis.Infrastracture; 
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DoctorDashboardDto = Diagnosis.Application.DTOs.Dashboard.DoctorDashboar.DoctorDashboardDto;

namespace Diagnosis.Infrastracture.Repositories
{
    public class DoctorRepository : IRepository<Doctor>, IDoctorManagement, IDoctorDashboardService
    {
        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context) : base()
        {
            _context = context;
        }
        public IQueryable<Doctor> Query()
              => _context.Set<Doctor>().AsQueryable();

        public async Task<List<Doctor>> GetAllAsync()
            => await _context.Set<Doctor>().ToListAsync();

        public async Task<HashSet<Doctor>> GetAllPagedAsync(
            int pageSize,
            int pageNumber,
            Expression<Func<Doctor, object>> orderBy)
        {
            var data = await _context.Set<Doctor>()
                .OrderBy(orderBy)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return data.ToHashSet();
        }

        public async Task<List<Doctor>> GetManyAsync(
            Expression<Func<Doctor, bool>> predicate)
            => await _context.Set<Doctor>().Where(predicate).ToListAsync();

        public async Task<Doctor?> GetAsync(
            Expression<Func<Doctor, bool>> predicate)
            => await _context.Set<Doctor>().FirstOrDefaultAsync(predicate);

        public async Task<Doctor?> GetByIdAsync(object[] keyValues)
            => await _context.Set<Doctor>().FindAsync(keyValues);

        public async Task AddAsync(Doctor entity)
        {
            await _context.Set<Doctor>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Update(Doctor entity)
        {
            _context.Set<Doctor>().Update(entity);
            _context.SaveChanges();
        }

        public async Task<bool> DeleteAsync(params object[] id)
        {
            var entity = await _context.Set<Doctor>().FindAsync(id);
            if (entity is null) return false;

            _context.Set<Doctor>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        // ========== IDoctorManagement Implementation ==========
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
                Gender = null,
                DateOfBirth= DateTime.MinValue,



            };

        }

        Task<Application.DTOs.Dashboard.DoctorDashboardDto> IDoctorDashboardService.GetDashboardAsync(int doctorId)
        {
            throw new NotImplementedException();
        }


        public async Task<PagedResultDTO<PatientListDTO>> GetPatientsAsync(PatientSearchDTO patientSearchDTO)
        {
            var patientsQuery = _context.Patients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(patientSearchDTO.PatientName))
            {
                patientsQuery = patientsQuery.Where( p => p.FName.Contains(patientSearchDTO.PatientName) );
            }

            var totalCount = await patientsQuery.CountAsync();

            var patients = await patientsQuery
                .OrderByDescending(p => p.CreatedOn)
                .Skip((patientSearchDTO.PageNumber - 1) * patientSearchDTO.PageSize)
                .Take(patientSearchDTO.PageSize)
                .Select(p => new PatientListDTO
                {
                    PatientName = p.FName,
                    Id = p.Id,
                    Status = p.IsDeleted ? "InActive" : "Active" ,
                    Contact = p.User.PhoneNumber

                })
                .ToListAsync();
            return new PagedResultDTO<PatientListDTO>
            {
                Items = patients,
                TotalCount = totalCount,
                PageNumber = patientSearchDTO.PageNumber,
                PageSize = patientSearchDTO.PageSize

            };



        }

        public async Task<PatientProfileDetailsDTO> GetPatientProfileAsync(int patientId)
        {
            var patient = await _context.Patients
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == patientId);

            if (patient == null)
                throw new Exception("Patient not found");

         
            var medicalFiles = await _context.MedicalFiles
                .Where(x => x.PatientId == patientId)
                .ToListAsync();

            
            var inquiries = await _context.Inquiries
                .Where(x => x.PatientId == patientId && x.Status == ConsultationStatus.Accepted)
                .ToListAsync();

            return new PatientProfileDetailsDTO
            {
                PatientId = patient.Id,
                PatientName = patient.FName + " " + patient.LName,
                Gender = patient.Gender,
                PhoneNumber = patient.User?.PhoneNumber,
                ImageUrl = patient.ProfileImageUrl,

                MedicalRecordDTO = new MedicalRecordDTO
                {
                    Symptoms = string.Join(", ", inquiries.Select(i => i.Symptoms)),
                    Allergies = patient.Allergies
                },

                LabTests = medicalFiles
                    .Where(x => x.Type == FileType.LabTest)
                    .Select(x => new FileDTO
                    {
                        Name = x.Name,
                        FileUrl = x.FileUrl!
                    }).ToList(),

                XRays = medicalFiles
                    .Where(x => x.Type == FileType.XRay)
                    .Select(x => new FileDTO
                    {
                        Name = x.Name,
                        FileUrl = x.FileUrl!
                    }).ToList(),

                TreatmentPlans = inquiries
                    .Where(x => !string.IsNullOrEmpty(x.TreatmentUrl))
                    .Select(x => new TreatmentFileDTO
                    {
                        Name = "Treatment Plan",
                        Url = x.TreatmentUrl!
                    }).ToList(),

                Prescriptions = inquiries
                    .Where(x => !string.IsNullOrEmpty(x.PrescriptionUrl))
                    .Select(x => new TreatmentFileDTO
                    {
                        Name = "Prescription",
                        Url = x.PrescriptionUrl!
                    }).ToList()
            };
        }

    }
    
}

