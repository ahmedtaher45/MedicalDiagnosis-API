using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum AppointmentStatus
    {
        Pending,
        Confirmed,
        Canceled,
        Completed
    }
    public class Appointment: BaseEntity
    {

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string? AppointmentType { get; set; }
        public string? Status { get; set; }
        public string? ConsultationType { get; set; }
        public string?  Notes { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public Prescription? Prescription { get; set; }
        public Review? Review { get; set; }
        // Scheduled, Completed, Canceled
    }
}
