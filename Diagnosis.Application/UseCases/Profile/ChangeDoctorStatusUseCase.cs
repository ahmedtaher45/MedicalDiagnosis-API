using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class ChangeDoctorStatusUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeDoctorStatusUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExecuteAsync(int doctorId, bool isActive)
        {
            if (doctorId <= 0) return false;

            var success = await _unitOfWork.Doctor.SetDoctorStatusAsync(doctorId, isActive);
            await _unitOfWork.SaveChangesAsync();
            return success;
        }
    }
}
