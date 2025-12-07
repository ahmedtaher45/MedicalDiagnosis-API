using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Patient: BaseEntity
    {
        
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string Allergies { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool IsNewPatient { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime UpdatedAt { get; set; }

        //// Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Billing> Billings { get; set; }
        public ICollection<Request> Requests { get; set; }

    }
}
