using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class TopDoctorsDto
    {
        public List<ChartDataPointDto> Doctors { get; set; } = new();
    }
}
