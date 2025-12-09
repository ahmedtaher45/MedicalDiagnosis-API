using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class AuthRepository: IAuth
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterDTO registerDTO)
        {
            var user = userManager.FindByEmailAsync(registerDTO.Email!);
            if (user == null)
            {
                return new RegisterResponse
                {
                    Success = false,
                    ErrorMessage = "Invalid Email"
                };
            }
            ApplicationUser newUser = new ApplicationUser
            {
                Email = registerDTO.Email,
                UserName = registerDTO.UserName,
                PhoneNumber = registerDTO.PhoneNumber
            };
            var result = await userManager.CreateAsync(newUser, registerDTO.Password!);

            if (!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    ErrorMessage = "Error occured while creating user"
                };
            }
            return new RegisterResponse
            {
                Success = true
            };
        }
    }
}
