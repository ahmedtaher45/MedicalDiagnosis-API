using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Domain.Shared;
using System;

namespace Diagnosis.Domain.Entities
{
    public class Prescription : BaseEntity
    {
        public string? PrescriptionId { get; set; } = Guid.NewGuid().ToString();

        // Relations
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public string? DoctorId { get; set; }
        public ApplicationUser? Doctor { get; set; }

        public string? TreatmentPlanId { get; set; }
        public TreatmentPlan? TreatmentPlan { get; set; }

        // Prescription Details
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Instructions { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
