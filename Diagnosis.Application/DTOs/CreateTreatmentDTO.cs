using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class CreateTreatmentDTO
    {
        [Required]
        public string Name { get; set; }

        public string Dosage { get; set; }
        public string Method { get; set; }
        public string Frequency { get; set; }
        public string TotalDuration { get; set; }
        public string Alternatives { get; set; }
        public int? PatientId { get; set; }
        public List<int> SideEffectIds { get; set; } = new List<int>();
        //
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Description { get; set; }
        //public string Type { get; set; }
        //public decimal? Cost { get; set; }
        //public string? Code { get; set; }
        //public int? Duration { get; set; }
        //public string Dosage { get; set; } // الجرعة (60 mg/m²)
        //public string Method { get; set; } // طريقة الإعطاء (IV)
        //public string Frequency { get; set; } // التكرار (3 times/week)
        //public int PatientId { get; set; }

        //public string Instructions { get; set; }
        //public List<string> SideEffects { get; set; } = new List<string>();
        // public bool IsActive { get; set; } = true;
    }
}
