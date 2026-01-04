using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Profile
{
    public class DoctorListItemDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;      // Sara Ali

        public int? ExperienceYears { get; set; }           // 10

        public string Gender { get; set; } = null!;        // "Male" / "Female"
        public string ProfileImageUrl { get; set; } = null!;

        public int ConsultationsCount { get; set; }        // +10, +8 ...

        public DateTime? LastConsultationDate { get; set; }  // Dec 12, 2025

        public string Status { get; set; } = null!;                 // Active / Inactive
    }
}

