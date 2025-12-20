using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class SuggestedTreatmentDTO
    {

        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Method { get; set; }
        public string Frequency { get; set; }
        public string TotalDuration { get; set; }
        public string Alternatives { get; set; }


      
    }
}
