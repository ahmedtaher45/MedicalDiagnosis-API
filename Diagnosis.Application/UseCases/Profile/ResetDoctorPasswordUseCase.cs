using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class ResetDoctorPasswordUseCase
    {

        private readonly IUnitOfWork _unitOfWork;

        public ResetDoctorPasswordUseCase(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }

        public async Task<bool> ExecuteAsync(int doctorId, string newPassword)
        {
            var result = await _unitOfWork.Doctor.ResetPasswordAsync(doctorId, newPassword);
            return result;
        }
}   }
