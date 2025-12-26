using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.SupportTicket
{
    public class SupportTicketDTO
    {
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        [MaxLength(150)]
        public string Subject { get; set; }
       
        [MaxLength(2000)]
        public string Details { get; set; }
        public string? Status { get; set; }
        public string? Reply { get; set; }
    }
  
}
