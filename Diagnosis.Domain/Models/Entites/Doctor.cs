using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Doctor: BaseEntity
    {
        
        public string FName { get; set; }
        public string LName { get; set; }
        public string Specialization { get; set; }
        public string Bio { get; set; }
        public int? ExperienceYears { get; set; }
        public decimal? Rating { get; set; }
        public string LicenseNumber { get; set; }
        public string ProfileImageUrl { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<DoctorClinic> DoctorClinics { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Request> Requests { get; set; }



    }
}
