using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
   
    public class ChartDataPointDto
    {
        public string Label { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
