using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
    public class PregnancyRiskCategory: BaseEntity
    {
        /// <summary>
        /// A, B, C, D, X, N
        /// </summary>
        public string Category { get; set; } = string.Empty;

        public string RiskLevel { get; set; } = string.Empty;

        public string RecommendedAction { get; set; } = string.Empty;
    }
}
