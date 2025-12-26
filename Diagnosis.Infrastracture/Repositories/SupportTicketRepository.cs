using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
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
                Subject = supportTicketDTO.Subject,
                Details = supportTicketDTO.Details
            };
            _context.Add(ticket);
            _context.SaveChanges();

        }
    }
}
