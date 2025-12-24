using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string FullName => $"{FName} {LName}";
        public string Specialization { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
        public decimal Rating { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AppointmentsCount { get; set; }
    }
}
