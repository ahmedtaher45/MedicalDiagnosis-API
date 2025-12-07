using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
   public class PrescriptionItem: BaseEntity
    {
        public int ItemId { get; set; }
        
        public string MedicineName { get; set; }
        public Prescription Prescription { get; set; }
    }
}
