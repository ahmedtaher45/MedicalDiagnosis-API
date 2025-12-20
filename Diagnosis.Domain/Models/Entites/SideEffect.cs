using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
     public class SideEffect: BaseEntity
    {
        public string Name { get; set; } // مثال: Fatigue, Hair Loss
        public string Description { get; set; }
        public bool IsSevere { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
