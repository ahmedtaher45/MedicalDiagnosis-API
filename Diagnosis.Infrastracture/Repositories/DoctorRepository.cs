using Diagnosis.Application.DTOs.Dashboard;
using Diagnosis.Application.DTOs.Dashboard.DoctorDashboar;
using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture; // <-- Ensure this matches the actual namespace where AppDbContext is defined
using Diagnosis.Infrastracture; 
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture;
using Microsoft.AspNetCore.Identity;
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
    public class DoctorRepository : Repository<Doctor>, IDoctorManagement
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId)
        {
            var doctor = await _context.Doctors
                .Include(d => d.User)
                .Include(d => d.Inquiries)
                .ThenInclude(i => i.Patient)
                .Include(d => d.BoneFractions)
                .ThenInclude(b => b.Patient)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null) return null;

            return new DoctorProfileDto
            {
                Id = doctor.Id,
                FullName = doctor.FName + " " + doctor.LName,
                Specialization = doctor.Specialization,
                IsActive = doctor.IsDeleted == false,
                Email = doctor.User.Email,
                PhoneNumber = doctor.User.PhoneNumber,
                Gender = doctor.Gender,
                DateOfBirth = doctor.BirhDate,
                Address = doctor.Address,
                NationalId = doctor.NationalId,
                ProfileImageUrl = doctor.ProfileImageUrl,
                TotalConsultations = doctor.Inquiries.Count + doctor.BoneFractions.Count,
                ActivePatients = doctor.Inquiries.Count(i => i.Patient.IsDeleted == false) + doctor.BoneFractions.Count(b => b.Patient.IsDeleted == false),
                ConsultationHistory = doctor.Inquiries
                    .Select(c => new DoctorProfileConsultationsDto
                    {
                        ConsultationId = c.Id,
                        DoctorName = "Dr. " + doctor.FName + " " + doctor.LName,
                        Specialization = doctor.Specialization,
                        ConsultationType = "inquiry",
                        ConsultationDate = c.CreatedOn
                    })
                    .Concat(
                    doctor.BoneFractions
                        .Select(b => new DoctorProfileConsultationsDto
                        {
                            ConsultationId = b.Id,
                            DoctorName = "Dr. " + doctor.FName + " " + doctor.LName,
                            Specialization = doctor.Specialization,
                            ConsultationType = "Bone Fracture",
                            ConsultationDate = b.CreatedOn
                        })
                )
                .OrderByDescending(x => x.ConsultationDate)
                .ToList()
            };
        }
        
        public async Task<IEnumerable<DoctorListItemDto>> GetDoctorsAsync(string? search,bool? isActive)
        {
            var query = _context.Doctors
       .Include(d => d.User)
       .Include(d => d.Inquiries)
       .Include(d => d.BoneFractions)
       .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(d =>
                    (d.FName + " " + d.LName).Contains(search));
            }

            if (isActive.HasValue)
            {
                query = query.Where(d =>
                    d.IsDeleted == !isActive.Value);
            }

            return await query
                .Select(d => new DoctorListItemDto
                {
                    Id = d.Id,
                    FullName = d.FName + " " + d.LName,
                    ExperienceYears = d.ExperienceYears,
                    Gender = d.Gender,
                    ProfileImageUrl = d.ProfileImageUrl,
                    ConsultationsCount = d.Inquiries.Count + d.BoneFractions.Count,
                    LastConsultationDate =
                    d.Inquiries
                        .Select(i => i.CreatedOn)
                        .Concat(
                            d.BoneFractions.Select(b =>b.CreatedOn)
                        )
                        .OrderByDescending(x => x)
                        .FirstOrDefault(),

                    Status = d.IsDeleted ? "Inactive" : "Active"
                })
                .ToListAsync();
        }
        public async Task<bool> SetDoctorStatusAsync(int doctorId, bool isActive)
        {
            var doctor = await _context.Doctors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null) return false;

           doctor.IsDeleted = !isActive;
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<bool> ResetPasswordAsync(int doctorId, string newPassword)
        {
            var doctor = await _context.Doctors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == doctorId);

            if (doctor == null || doctor.User == null) return false;
            var user = doctor.User;

           
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

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


