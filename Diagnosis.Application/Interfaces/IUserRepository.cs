using Diagnosis.Application.DTOs.Auth;
using Diagnosis.Application.DTOs.DoctorManagement;
using Diagnosis.Application.DTOs.SystemSettings;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IUserRepository: IRepository<ApplicationUser>
    {
        Task<IList<ApplicationUser>> GetUsersByRoleAsync(string role);
        Task<string> GetUserRoleAsync(string userId);
    }
}