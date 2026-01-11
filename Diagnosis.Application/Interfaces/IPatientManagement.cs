using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IPatientManagement: IRepository<Patient>
    {
        Task<PatientProfileDto?> GetPatientProfileAsync(int patientId);

        // 2) قائمة المرضى للـ Patient Table مع البحث وحالة (Active / Deleted)
        Task<IEnumerable<PatientListItemDto>> GetPatientsAsync( string? search,string? status); 
           
                 // "Active" أو "Deleted"

        // 3) تغيير حالة المريض (حذف منطقي = Deleted / Active)
        Task<bool> SetPatientStatusAsync(int patientId, bool isDeleted);
    }
}