using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.AdminDashboard
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string FullName => $"{FName} {LName}";
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string BloodType { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Allergies { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public bool IsNewPatient { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Age => DateOfBirth.HasValue ? DateTime.Now.Year - DateOfBirth.Value.Year : 0;
    }
}
