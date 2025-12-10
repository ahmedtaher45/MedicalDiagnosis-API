using Diagnosis.Application.DTOs;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Application.DTOs;
 
namespace Diagnosis.Application.Interfaces
{
    public interface IAuth
    {
        Task<RegisterResponse> RegisterAsync(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginAsync(string email, string password, string role);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
    }
}
