using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Prescription: BaseEntity
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string? Specialization { get; set; }
        public string? Notes { get; set; }
        public string? DiagnosisName { get; set; }
        public string? Severity { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public ICollection<PrescriptionItem>? PrescriptionItems { get; set; }
    }
}
