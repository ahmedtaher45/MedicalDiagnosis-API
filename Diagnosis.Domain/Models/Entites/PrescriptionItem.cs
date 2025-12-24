using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
   public class PrescriptionItem: BaseEntity
    {

        [ForeignKey("Prescription")]
        public int PrescriptionId { get; set; }
        public string? MedicineName { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
