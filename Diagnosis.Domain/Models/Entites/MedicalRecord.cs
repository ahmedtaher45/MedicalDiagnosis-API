using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum RecordType
    {
        Allergy,
        Disease,
        Surgery,
        Vaccination
    }
    public class MedicalRecord: BaseEntity
    {
        //
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
       
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiagnosisDetails { get; set; }
        public string Prescriptions { get; set; }
        public string Notes { get; set; }
    }
}
