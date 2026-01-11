using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Profile
{
    public class PatientListItemDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;      // John Smith

        public DateTime? BirthDate { get; set; }                       // 45y

        public string Gender { get; set; } = null!;        // Male / Female

        public string ProfileImageUrl { get; set; } = null!;

        public int DiagnosesCount { get; set; }            // +8, +5 ...

        public DateTime? LastDiagnosisDate { get; set; }   // Dec 15, 2025

        public string Status { get; set; } = null!;        // Active / Delete
    }
}