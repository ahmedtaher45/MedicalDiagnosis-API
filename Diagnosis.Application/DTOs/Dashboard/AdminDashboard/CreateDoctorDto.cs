using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class CreateDoctorDto
    {
        public string UserId { get; set; } = string.Empty;
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
    }
}
