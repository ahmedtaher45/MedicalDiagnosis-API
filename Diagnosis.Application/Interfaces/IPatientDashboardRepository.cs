using Diagnosis.Application.DTOs.PatientDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IPatientDashboardRepository
    {
        Task<List<DoctorListDTO>> GetDoctorList();
    }
}
