using Diagnosis.Application.DTOs.Auth;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diagnosis.Application.UseCases.Auth
{
    public class RegisterUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public RegisterUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<RegisterResponse> ExcuteAsync(RegisterDTO registerDTO)
        {
            var admins = await unitOfWork.Users.GetUsersByRoleAsync("Admin");
           foreach (var admin in admins)
            {
                await unitOfWork.Notifications.AddAsync(new Diagnosis.Domain.Entites.Notification
                {
                    UserId = admin.Id,
                    Title = "New Patient Registered",
                    Message = "A new patient has joined the platform",
                    NotificationType = Diagnosis.Domain.Entites.NotificationType.DoctorPatientManagement,
                    Date = DateTime.UtcNow,
                });
                await unitOfWork.SaveChangesAsync();
            }        
            return await unitOfWork.Auth.RegisterAsync(registerDTO); 
        }

    }
}
