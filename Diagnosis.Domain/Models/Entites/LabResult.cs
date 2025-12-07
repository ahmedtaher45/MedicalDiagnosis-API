using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class LabResult: BaseEntity
    {
        
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string TestName { get; set; }
        public DateTime TestDate { get; set; }
        public string ResultValue { get; set; }
        public string ResultStatus { get; set; }
        public string LabNotes { get; set; }
        public string FileUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    
    }
}
