using Diagnosis.Application.DTOs.SupportTicket;
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
    public class SupportTicketRepository :Repository<SupportTicket>, ISupportTicket
    {
        private readonly ApplicationDbContext _context;
        public SupportTicketRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }
        public async Task CreateSupportTicketAsync(SupportTicketDTO supportTicketDTO)
        {
            if (string.IsNullOrWhiteSpace(supportTicketDTO.Subject))
                throw new ArgumentNullException("Subject is requred");

            if (string.IsNullOrWhiteSpace(supportTicketDTO.Details))
                throw new ArgumentNullException("Details is requred");

            var ticket = new SupportTicket
            {
                DoctorId = supportTicketDTO.DoctorId,
                PatientId = supportTicketDTO.PatientId,
                Subject = supportTicketDTO.Subject,
                Details = supportTicketDTO.Details,
                Status = supportTicketDTO.Status
            };
            _context.Add(ticket);
  
            _context.SaveChanges();

        }

        public async Task<List<GetSupportTicketDTO>> GetSupportTicketsAsync()
        {
            var tickets = await _context.SupportTickets
        .Include(t => t.Doctor)
        .Include(t => t.Patient)
        .Select(t => new GetSupportTicketDTO
        {
            DoctorId = t.DoctorId,
            DoctorName = t.Doctor != null ? t.Doctor.FName : null,
            Experience = t.Doctor != null ? t.Doctor.ExperienceYears : null,

            PatientId = t.PatientId,
            PatientName = t.Patient != null ? t.Patient.FName : null,

            Subject = t.Subject,
            Status = t.Status
        })
        .ToListAsync();
            return tickets;

        }
    }
}
