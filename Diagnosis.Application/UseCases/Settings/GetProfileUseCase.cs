using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.Settings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Settings
{
    public class GetProfileUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetProfileUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }
       public async Task<ProfileDto?> GetPatientProfile(string id)
    {
        var user = await _unitOfWork.Profile.GetByIdAsync([id]);

        if (user == null)
        {
            return null;
        }
       
        return new ProfileDto
        {
            FullName = $"{user.UserName} ",
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
        };
    }
    }
}