using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public class Diagnos: BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DiagnosisName { get; set; }
        public decimal AccuracyPercentage { get; set; }
        public string ConditionDescription { get; set; }
        public string AiModelUsed { get; set; }
        public string ImageUrl { get; set; }
        public string SymptomsText { get; set; }
        public JsonDocument FollowUpQuestions { get; set; }

        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
    }
}
