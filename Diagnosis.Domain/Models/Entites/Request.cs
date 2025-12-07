using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Request: BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string RequestType { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Message { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
