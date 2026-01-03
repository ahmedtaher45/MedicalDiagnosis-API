using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Treatment
{
    public class CreatePrescriptionDto
    {
        [Required]
        public string? PatientId { get; set; }
        [Required]
        public string? DoctorId { get; set; }
        public string? TreatmentPlanId { get; set; }
        [Required]
        public string? MedicationName { get; set; }
        [Required]
        public string? Dosage { get; set; }
        [Required]
        public string? Frequency { get; set; }
        [Required]
        public string? Duration { get; set; }
        public string? Instructions { get; set; }
        public string? Notes { get; set; }
    }
}
