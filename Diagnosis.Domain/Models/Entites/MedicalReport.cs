using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Entites
{
    public enum ReportType
    {
        Lab,
        Radiology,
        Pdf,
        Other
    }
    public class MedicalReport: BaseEntity
    {
        public int PatientId { get; set; }
        public ReportType ReportType { get; set; }
        public string ReportName { get; set; }
        public string FileUrl { get; set; }
        public int UploadedByDoctorId { get; set; }
        public DateTime UploadDate { get; set; }
        public string Notes { get; set; }
       

        // Navigation Properties
        public Patient Patient { get; set; }
        public Doctor UploadedByDoctor { get; set; }
    }
}
