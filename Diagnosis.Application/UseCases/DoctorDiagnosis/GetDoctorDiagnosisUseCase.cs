using Diagnosis.Application.DTOs.DoctorDiagnosis;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.DoctorDiagnosis
{
    public class GetDoctorDiagnosisUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorDiagnosisUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<DoctorDiagnosisResponse> ExecuteAsync(GetDoctorDiagnosisDTO diagnosisDTO)
        {
            return await _unitOfWork.DoctorDiagnosisProvider.GetDoctorDiagnosisAsync(diagnosisDTO);
        }
    }
}
