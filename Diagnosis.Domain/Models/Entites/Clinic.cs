using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
   public class Clinic: BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        // Navigation Properties
        public ICollection<DoctorClinic> DoctorClinics { get; set; }
    }
}
