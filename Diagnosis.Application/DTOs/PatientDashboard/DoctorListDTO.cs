using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.PatientDashboard
{
    public class DoctorListDTO
    {
        public string Name { get; set; }
        public string? Specialization { get; set; }
        public string? Address { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int? ExperienceYears { get; set; }
        public decimal? Rating { get; set; }
    }
}
