using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum InteractionLevel
    {
        Severe,
        Moderate,
        Mild
    }
    public class DrugInteraction: BaseEntity
    {
        public string DrugName1 { get; set; }
        public string DrugName2 { get; set; }
        public InteractionLevel InteractionLevel { get; set; }
        public string Description { get; set; }
        public JsonDocument ConditionsApplicable { get; set; }
        public string Recommendation { get; set; }
       
    }
}
