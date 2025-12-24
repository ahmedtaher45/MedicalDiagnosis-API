using Diagnosis.Application.DTOs.Auth;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly IEmailSender emailSender;
        private readonly ApplicationDbContext _context;
        public AuthRepository(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator, IEmailSender emailSender, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.emailSender = emailSender;
            _context = context;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterDTO registerDTO)
        {
            if (registerDTO.Email == null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid Email"
                };
            }
            ApplicationUser? user = null;

            try
            {
                user = new ApplicationUser
                {
                    Email = registerDTO.Email,
                    UserName = registerDTO.UserName,
                    PhoneNumber = registerDTO.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, registerDTO.Password!);

                if (!result.Succeeded)
                {
                    return new RegisterResponse
                    {
                        Success = false,
                        ErrorMessage = string.Join(", ", result.Errors.Select(e => e.Description))
                    };
                }
                if (string.IsNullOrEmpty(user.Id))
                {
                    return new RegisterResponse
                    {
                        Success = false,
                        ErrorMessage = "User ID is null after creation"
                    };
                }

                await userManager.AddToRoleAsync(user, "Patient");

            var patient = new Patient
            {
                UserId = user.Id,
                FName = registerDTO.FName!,
                LName = registerDTO.LName!,
                Gender = registerDTO.Gender!,
                DateOfBirth = registerDTO.BirthDate
                };

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
            }
                catch (Exception ex)
                {
                    if (user != null)
                        await userManager.DeleteAsync(user);

                      var errorMessage = ex.InnerException != null
                            ? ex.InnerException.Message
                            : ex.Message;

                    return new RegisterResponse
                    {
                        Success = false,
                        ErrorMessage = "Error: " + errorMessage + " | StackTrace: " + ex.StackTrace
                    };
                }

                    await SendConfirmationEmail(user, registerDTO.ClientUri!);
                    return new RegisterResponse
                    {
                        Success = true,
                        ErrorMessage = "Check your Email for Confirmation"
                    };
            }
            

        public async Task SendConfirmationEmail(ApplicationUser user, string clientUri)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var encodedToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var param = new Dictionary<string, string?>
            {
                { "token", encodedToken},
                { "email", user.Email!}
            };

            var callBackUrl = QueryHelpers.AddQueryString(clientUri, param);

            var assembly = Assembly.Load("Diagnosis.Application");
            using var  stream = assembly.GetManifestResourceStream("Diagnosis.Application.Template.ConfirmEmail.html");
            
            if (stream == null) throw new Exception("stream file of Email template is not correct");

            using var reader = new StreamReader(stream);
            var htmlTemplate = await reader.ReadToEndAsync();

            var html = htmlTemplate.Replace("{{CallbackUrl}}", callBackUrl);

            var message = new Message(
                new string[] { user.Email! },
                "Confirm your Email",
                html);

            await emailSender.SendEmailAsync(message);
        }
        public async Task<RegisterResponse> ConfirmEmailAsync(ConfirmEmailDTO confirmEmailDTO)
        {
            if (confirmEmailDTO.Email == null) throw new ArgumentNullException(nameof(confirmEmailDTO.Email));
            if (confirmEmailDTO.Token == null) throw new ArgumentNullException(nameof(confirmEmailDTO.Token));

            var user = await userManager.FindByEmailAsync(confirmEmailDTO.Email);
            if (user == null) return new RegisterResponse { Success = false, ErrorMessage = "user Doesn't Exist" };

            var decodedToken = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(confirmEmailDTO.Token));
            var result = await userManager.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    ErrorMessage = "Error with confirming Email" 
                };
            }                                            
            return new RegisterResponse
            {
                Success = true,
                ErrorMessage = "Email confirmed Successfully"
            };
        }
        public async Task<LoginResponseDTO> LoginAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return (new LoginResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Invalid email or password"
                });
            }

            if (!user.EmailConfirmed)
            {
                return (new LoginResponseDTO
                {
                    Success = false,
                    ErrorMessage = "You must confirm your Email, please return to your gmail"
                });
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
            {
                return (new LoginResponseDTO
                {
                    Success = false,
                    ErrorMessage = "Invalid email or password"
                });
            }

            var roles = await userManager.GetRolesAsync(user);
     
            var (token, expiresAt) = await jwtTokenGenerator.GenerateTokenAsync(user, roles);


            return new LoginResponseDTO
            {
                Token = token,
                ExpiresAt = expiresAt
            };

        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            return await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {
            var result = await userManager.FindByIdAsync(userId!);
            if (result == null) throw new ArgumentNullException("Invalid userId");
            return result;
        }

        public async Task<ForgotPasswordResponseDTO> ForgotPasswordAsync(ForgotPasswordDTO forgotPasswordDTO)
        {
            var user = await userManager.FindByEmailAsync(forgotPasswordDTO.Email!);
            if (user == null)
            {
                throw new Exception($"User with email {forgotPasswordDTO.Email} not found");
            }

            
            var token = await userManager.GeneratePasswordResetTokenAsync(user);         

            
            if (!string.IsNullOrEmpty(forgotPasswordDTO.ClientUri))
            {
                var param = new Dictionary<string, string?>
                {
                    { "token", token },
                    { "email", forgotPasswordDTO.Email! }
                };

                string callbackUrl = QueryHelpers.AddQueryString(forgotPasswordDTO.ClientUri, param);

                #region Read Html file
                var assembly = Assembly.Load("Diagnosis.Application");
                using var stream = assembly.GetManifestResourceStream("Diagnosis.Application.Template.ResetEmail.html");

                if (stream == null) throw new Exception("stream file of Email template is not correct");

                using var reader = new StreamReader(stream);
                var htmlTemplate = await reader.ReadToEndAsync();
                #endregion

                var html = htmlTemplate.Replace("{{CallbackUrl}}", callbackUrl);

                    var message = new Message(
                        new string[] { user.Email! },
                        "Reset Password Token",
                        html
                    );

                await emailSender.SendEmailAsync(message);

                return new ForgotPasswordResponseDTO
                {
                    Success = true
                };
            }

            return new ForgotPasswordResponseDTO
            {
                Success = false,
                Message = "Email with reset token hasn't sent"
            };
        }


        public async Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            
            var user = await userManager.FindByEmailAsync(resetPasswordDTO.Email!);
            if (user == null)
            {
                return new ResetPasswordResponseDTO
                {
                    Success = false,
                    Message = "User not found.",
                    Errors = new List<string> { "Invalid email." }
                };
            }

            
            if (string.IsNullOrEmpty(resetPasswordDTO.Token))
            {
                return new ResetPasswordResponseDTO
                {
                    Success = false,
                    Message = "Token is required.",
                    Errors = new List<string> { "Token cannot be empty." }
                };
            }

            
            string token = resetPasswordDTO.Token;

            
            var resetPassResult = await userManager.ResetPasswordAsync(
                user,
                token,
                resetPasswordDTO.Password!
            );

            
            if (!resetPassResult.Succeeded)
            {
                return new ResetPasswordResponseDTO
                {
                    Success = false,
                    Message = "Failed to reset password.",
                    Errors = resetPassResult.Errors.Select(e => e.Description).ToList()
                };
            }

            
            return new ResetPasswordResponseDTO
            {
                Success = true,
                Message = "Password has been reset successfully."
            };
        }
    }
}
