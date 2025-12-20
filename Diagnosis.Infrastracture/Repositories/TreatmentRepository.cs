using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        private readonly ApplicationDbContext _context;

        public TreatmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Treatment>> GetActiveTreatmentsAsync()
        {
            return await _context.Set<Treatment>()
                .Where(t => t.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Treatment>> GetAllTreatmentsAsync()
        {
            return await _context.Set<Treatment>()
                .ToListAsync();
        }

       

        public async Task<Treatment> GetTreatmentByIdAsync(int id)
        {
            return await _context.Set<Treatment>()
                .Include(t => t.Patient)
                .Include(t => t.SideEffects)
                .FirstOrDefaultAsync(t => t.Id == id);
           //return await _context.Set<Treatment>()
           //     .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Treatment>> GetTreatmentsByPatientIdAsync(int patientId)
        {
            return await _context.Set<Treatment>()
                .Where(t => t.PatientId == patientId)
                .ToListAsync();
        }
    }
}
