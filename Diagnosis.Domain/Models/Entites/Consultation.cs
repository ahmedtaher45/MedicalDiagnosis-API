using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Domain.Models.Entites
{
    public enum ConsultationStatus
    {
        Pending = 0,
        Accepted = 1,
        Rejected = 2
    }

    public enum ConsultationType
    {
        Inquiry = 0,
        AIDiagnosis = 1,
    }
    public class Consultation: BaseEntity
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string? Symptoms { get; set; }
        public string? Notes { get; set; }
        public ConsultationStatus Status { get; set; }
        public ConsultationType Type { get; set; }
        public DateTime Date { get; set; }
        public int ConfidenceLevel { get; set; }
        public ICollection<string>? FileUrls { get; set; }
        public string? DiagnosisName { get; set; }
        public string? Description { get; set; }
        public string? RejectReason { get; set; }
        public string? RejectNotes { get; set; }

        public decimal? Rating { get; set; }     //  RatingStats
        public decimal? Price { get; set; }      // EarningsStats
        public Patient? Patient { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
