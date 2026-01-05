using Diagnosis.Application.DTOs.Auth;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diagnosis.Application.UseCases.Auth
{
    public class LoginUseCase
    {
         
         private readonly IUnitOfWork _unitOfWork;

        public LoginUseCase(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        

        }

        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            var result =await _unitOfWork.Auth.LoginAsync(loginDTO.Email, loginDTO.Password, loginDTO.ClientUri);
            var admins = await _unitOfWork.Users.GetUsersByRoleAsync("Admin");
            if(!result.Success)
            {
                Console.WriteLine("Login failed for user: " + admins.Count);
                foreach (var admin in admins)
                {
                    await _unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
                    {
                        UserId = admin.Id,
                        Title = "Failed Login Attempts",
                        Message = "Multiple failed admin login attempts detected",
                        NotificationType = Diagnosis.Domain.Entites.NotificationType.SystemAlert,
                        Date = DateTime.UtcNow,
                    });
                    await _unitOfWork.SaveChangesAsync();
                }

            return await _unitOfWork.Auth.LoginAsync(loginDTO.Email, loginDTO.Password, loginDTO.ClientUri);
        }

            return result;
        }
    }
}