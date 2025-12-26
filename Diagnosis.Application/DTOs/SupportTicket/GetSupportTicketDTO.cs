using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.SupportTicket
{
    public class GetSupportTicketDTO
    {
        public int? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public int? PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? Experience { get; set; }
        public string? Subject { get; set; }
        public string? Status { get; set; }
    }
}
