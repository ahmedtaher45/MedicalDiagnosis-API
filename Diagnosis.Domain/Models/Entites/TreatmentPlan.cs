using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;

namespace Diagnosis.Domain.Models.Entites
{
    public class TreatmentPlan : BaseEntity
    {
       
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }
        public string? DoctorId { get; set; }
        public ApplicationUser? Doctor { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
    }
}