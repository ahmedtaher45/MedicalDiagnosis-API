using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class ChangePatientStatusUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangePatientStatusUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ExecuteAsync(int patientId, bool isDeleted)
        {
            if (patientId <= 0) return false;

            var ok = await _unitOfWork.Patient.SetPatientStatusAsync(patientId, isDeleted);
            await _unitOfWork.SaveChangesAsync();
            return ok;
        }
    }
}