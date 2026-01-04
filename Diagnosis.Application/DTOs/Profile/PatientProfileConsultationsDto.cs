using Diagnosis.Application.DTOs.Consultation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.DTOs.Profile
{
    public class PatientProfileConsultationsDto
    {
       public int ConsultationId { get; set; }
       public string DoctorName { get; set; }
       public string Specialization { get; set; }
       public string ConsultationType { get; set; }
       public DateTime? ConsultationDate { get; set; }

    }
}