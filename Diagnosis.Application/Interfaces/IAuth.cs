using Diagnosis.Application.DTOs.Auth;
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
    public interface IAuth
    {
        Task<RegisterResponse> RegisterAsync(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginAsync(string email, string password);
        Task SendConfirmationEmail(ApplicationUser user, string clientUri);
        Task<RegisterResponse> ConfirmEmailAsync(ConfirmEmailDTO confirmEmailDTO);
        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ForgotPasswordResponseDTO> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO);
        Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
    }
}
