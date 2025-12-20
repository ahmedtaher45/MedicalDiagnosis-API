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
         
         private readonly IAuth auth;

        public LoginUseCase( IAuth auth)
        {
           
            this.auth = auth;

        }

        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            return await auth.LoginAsync(loginDTO.Email, loginDTO.Password);

           
            
        }
    }
}