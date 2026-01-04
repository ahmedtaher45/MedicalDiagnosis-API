using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Shared;
using System;

namespace Diagnosis.Domain.Entities
{
    public class LabResult : BaseEntity
    {
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        public string? TestName { get; set; }
        public string? Result { get; set; }
        public DateTime TestDate { get; set; }
    }
}
