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
        public string PatientName { get; set; } = string.Empty;
        public int PatientId { get; set; }

        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;

        public string? Instructions { get; set; }
        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
