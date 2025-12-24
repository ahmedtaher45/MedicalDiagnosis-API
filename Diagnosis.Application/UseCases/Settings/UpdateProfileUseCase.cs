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
    public class UpdateProfileUseCase 
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProfileUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
         
        }
        public async Task<bool> UpdatePatientProfile(string id, ProfileDto profileDto)
        {
            var user = await _unitOfWork.Profile.GetByIdAsync([id]);

            if (user == null)
            {
                return false;
            }

            user.UserName = profileDto.FullName;
            user.Email = profileDto.Email;
            user.PhoneNumber = profileDto.PhoneNumber;

            _unitOfWork.Profile.Update(user);
            await  _unitOfWork.CompleteAsync();

            return true;
        }}}