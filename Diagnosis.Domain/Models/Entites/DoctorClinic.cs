using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class DoctorClinic: BaseEntity
    {
        
        public int DoctorId { get; set; }
        public int ClinicId { get; set; }
        public decimal ConsultationFees { get; set; }
        public decimal FollowUpFees { get; set; }
        public Doctor Doctor { get; set; }
        public Clinic Clinic { get; set; }
    }
}
