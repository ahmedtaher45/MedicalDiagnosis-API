using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
    public class Treatment : BaseEntity
    {

        public string Name { get; set; } // مثال: Paclitaxel
        public string Dosage { get; set; } // مثال: 180 mg/m2
        public string Method { get; set; } // مثال: 3 hours
        public string Frequency { get; set; } // مثال: Every 3 weeks
        public string TotalDuration { get; set; } // مثال: (0 to 6 days) 3 weeks
        public string Alternatives { get; set; } // مثال: Docetaxel, Nab-Paclitaxel
        public bool IsActive { get; set; } = true;
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<SideEffect> SideEffects { get; set; } = new List<SideEffect>();


        // Relations

        // public virtual ICollection<PrescriptionItem> PrescriptionItems { get; set; }
    }  
}
