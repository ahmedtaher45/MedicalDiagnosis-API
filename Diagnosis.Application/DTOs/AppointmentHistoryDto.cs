using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs
{
    public class AppointmentHistoryDto
    {
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Diagnosis { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }
}
