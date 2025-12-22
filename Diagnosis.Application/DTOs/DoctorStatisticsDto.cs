using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class DoctorStatisticsDto
    {
        public int TotalAppointments { get; set; }
        public int AIConsultations { get; set; }
        public int CompletedConsultations { get; set; }
        public int ActivePatients { get; set; }
    }
}
