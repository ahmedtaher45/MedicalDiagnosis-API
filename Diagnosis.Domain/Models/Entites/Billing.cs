using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Billing: BaseEntity
    {
      
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime CreatedAt { get; set; }
        public Patient Patient { get; set; }
    }
}
