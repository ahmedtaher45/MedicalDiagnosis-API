using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
    public class Drug: BaseEntity
    {
        public string DrugName { get; set; } = string.Empty;
        public string RxOtc { get; set; } = string.Empty;
        public string DrugClasses { get; set; } = string.Empty;
        public string Csa { get; set; } = string.Empty;
        public string Alcohol { get; set; } = string.Empty;
        public string GenericName { get; set; } = string.Empty;
        public string MedicalCondition { get; set; } = string.Empty;
        public int Activity { get; set; }
    }
}
