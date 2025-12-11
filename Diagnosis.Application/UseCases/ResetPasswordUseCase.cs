using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases
{
    public class ResetPasswordUseCase
    {
        private readonly IUnitOfWork unitOfWork;
        public ResetPasswordUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ResetPasswordResponseDTO> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO)
        {
            return await unitOfWork.Auth.ResetPasswordAsync(resetPasswordDTO);
        }
    }
}
