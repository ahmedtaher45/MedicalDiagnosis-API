using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.DrugChecker
{
    public class DrugCheckerResponce
    {
        [JsonPropertyName("predicted_pregnancy_type")]
        public string? PredictedType { get; set; }
    }

    public class DrugCheckerResponceDTO
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public string RecommendedAction { get; set; } = string.Empty;
    }

    public class DrugCheckerRequestDTO
    {
        public string? DrugName { get; set; }
       
    }
    public class DrugCheckerApiRequest
    {
        [JsonPropertyName("drug_name")]
        public string DrugName { get; set; } = string.Empty;

        [JsonPropertyName("rx_otc")]
        public string RxOtc { get; set; } = string.Empty;

        [JsonPropertyName("drug_classes")]
        public string DrugClasses { get; set; } = string.Empty;

        [JsonPropertyName("csa")]
        public string Csa { get; set; } = string.Empty;

        [JsonPropertyName("alcohol")]
        public string Alcohol { get; set; } = string.Empty;

        [JsonPropertyName("generic_name")]
        public string GenericName { get; set; } = string.Empty;

        [JsonPropertyName("medical_condition")]
        public string MedicalCondition { get; set; } = string.Empty;

        [JsonPropertyName("activity")]
        public int Activity { get; set; }
    }


}