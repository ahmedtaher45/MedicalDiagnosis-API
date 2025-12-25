using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class SupportTicketDTO
    {
        [Required]
        [MaxLength(150)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Details { get; set; }
    }
  
}
