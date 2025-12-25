using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
    public class Faq: BaseEntity
    {
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }
}
