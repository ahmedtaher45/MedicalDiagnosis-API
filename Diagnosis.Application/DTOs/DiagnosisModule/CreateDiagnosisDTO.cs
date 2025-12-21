using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.DiagnosisModule
{
    public class CreateDiagnosisDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public ICollection<IFormFile>? Files { get; set; }
        public string? Symptoms { get; set; }
        public string? Description { get; set; }
    }
}
