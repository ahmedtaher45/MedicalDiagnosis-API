using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.DiagnosisModule
{
    public class ProviderResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public ICollection<FollowUpQuestionDto>? FollowUpQuestions { get; set; }
        public string? DiagnosisName { get; set; }
        public string? DiagnosisDescription { get; set; }
        public int ConfidenceLevel { get; set; }
    }
    public class FollowUpQuestionDto
    {
        public string Question { get; set; } = default!;
        public string? Answer { get; set; }
    }

}
