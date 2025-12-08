using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Diagnosis.Application.UseCases
{
    public class RegisterUseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public RegisterUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Register(RegisterDTO registerDTO)
        {
            return "";
        }
    }
}
