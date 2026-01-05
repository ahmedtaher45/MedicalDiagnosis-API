using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Treatment
{
    public class PrescriptionResponseDto
    {
        public string? Id { get; set; }
        public string? PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientIdentifier { get; set; }
        public string? DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? TreatmentPlanId { get; set; }
        public string? MedicationName { get; set; }
        public string? Dosage { get; set; }
        public string? Frequency { get; set; }
        public string? Duration { get; set; }
        public string? Instructions { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
