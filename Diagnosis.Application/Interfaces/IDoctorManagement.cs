using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IDoctorManagement:IRepository<Doctor>
    {
        // 2) بروفايل دكتور واحد (اللي كتبتيه)
        Task<DoctorProfileDto?> GetDoctorProfileAsync(int doctorId);
        // 1) قائمة الأطباء مع فلترة بالاسم والحالة
        Task<IEnumerable<DoctorListItemDto>> GetDoctorsAsync( string? search,  bool? isActive);

        // 3) تفعيل / إلغاء تفعيل دكتور
        Task<bool> SetDoctorStatusAsync(int doctorId, bool isActive);
        // 4) Reset Password (ترجعي true/false بس)
        Task<bool> ResetPasswordAsync(int doctorId, string newPassword);
    }






}

