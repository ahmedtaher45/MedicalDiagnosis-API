using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class PatientDasboardRepository : IPatientDashboardRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientDasboardRepository(ApplicationDbContext context) : base()
        {

            _context = context;


        }
        public async Task<List<DoctorListDTO>> GetDoctorList()
        {
            var doctors = await _context.Doctors
                 .Where(d => !d.IsDeleted)
                 .Select(d => new DoctorListDTO
                 {
                     Name = d.FName + " " + d.LName,
                     Specialization = d.Specialization,
                     Address = d.Address,
                     ProfileImageUrl = d.ProfileImageUrl,
                     ExperienceYears = d.ExperienceYears,
                     Rating = d.Rating
                 })
                 .OrderByDescending(d => d.Rating)
                 .ToListAsync();

            return doctors;
        }
    }
}
