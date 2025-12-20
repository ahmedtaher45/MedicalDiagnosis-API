using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class TreatmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Method { get; set; }
        public string Frequency { get; set; }
        public string TotalDuration { get; set; }
        public string Alternatives { get; set; }
        public bool IsActive { get; set; }
        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        public List<SideEffectDTO> SideEffects { get; set; } = new List<SideEffectDTO>();

        ////
        // public List<SideEffectDTO> SideEffects { get; set; } = new List<SideEffectDTO>();
        //
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Type { get; set; }
        //public decimal? Cost { get; set; }
        //public int? Duration { get; set; }
        //public string Method { get; set; }
        //public string Frequency { get; set; }
        //public string Instructions { get; set; }
        //public bool IsActive { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string Status { get; set; } // "Completed", "In Progress"
    }
}
