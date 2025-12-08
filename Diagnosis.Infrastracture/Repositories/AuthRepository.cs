using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Application.DTOs;

namespace Diagnosis.Infrastracture.Repositories
{
    public class AuthRepository: IAuth
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthRepository(UserManager<ApplicationUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> RegisterAsync(ApplicationUser dtoUser)
        {
            return "aa";
        }
        public async Task<LoginResponseDTO> LoginAsync(string email, string password, string role)
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
            if (!roles.Contains(role))
            {
                return (new LoginResponseDTO
                 {
                      Success = false,
                      ErrorMessage = "User does not have the required role"
                 });
            }
            var (token, expiresAt) = await jwtTokenGenerator.GenerateTokenAsync(user, roles);

            

            return new LoginResponseDTO
            {
                Token = token,
                ExpiresAt = expiresAt
            };
    
        }
    }
}
