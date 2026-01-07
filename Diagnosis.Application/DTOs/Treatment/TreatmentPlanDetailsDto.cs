using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Treatment
{
    public class TreatmentPlanDetailsDto
    {
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? Duration { get; set; }
        public string? Overview { get; set; }
        public List<KeyMedicationDto>? KeyMedications { get; set; }
        public HydrationDto? Hydration { get; set; }
        public RestrictionsDto? Restrictions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
