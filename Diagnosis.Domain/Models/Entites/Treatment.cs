using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
   public class Treatment: BaseEntity
    {
        public int DiagnosisId { get; set; }
        public int DoctorId { get; set; }
        public string TreatmentName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Method { get; set; }
        public string TotalDuration { get; set; }
       // public TreatmentStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Instructions { get; set; }
        public DateTime CreatedAt { get; set; }
        // Navigation Properties
        public Diagnos Diagnosis { get; set; }
        public Doctor Doctor { get; set; }
    }
}
