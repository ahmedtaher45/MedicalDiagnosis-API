using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Dashboard.DoctorDashboar
{
    public class PatientProfileDetailsDTO
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public MedicalRecordDTO MedicalRecordDTO { get; set; } = new MedicalRecordDTO();
        public List<FileDTO> LabTests { get; set; } = new List<FileDTO>();
        public List<FileDTO> XRays { get; set; } = new List<FileDTO>();
        public List<TreatmentFileDTO> TreatmentPlans { get; set; } = new List<TreatmentFileDTO>();
        public List<TreatmentFileDTO> Prescriptions { get; set; } = new List<TreatmentFileDTO>();

    }
}
