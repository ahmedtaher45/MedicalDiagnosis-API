using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class PhysiotherapySession:BaseEntity
    {
        public int PatientId { get; set; }
        public int AssignedDoctorId { get; set; }
        public string ExerciseName { get; set; }
        public string AreaTargeted { get; set; }
        public int PainLevel { get; set; }
        public decimal AdherencePercentage { get; set; }
        public DateTime SessionDate { get; set; }
        public int DurationMinutes { get; set; }
        public string AiFeedback { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
