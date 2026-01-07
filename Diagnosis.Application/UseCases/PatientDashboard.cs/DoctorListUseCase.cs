using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.PatientDashboard.cs
{
    public class DoctorListUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorListUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public async Task<List<DoctorListDTO>> GetDoctorList()
        {
            return await _unitOfWork.PatientDashboard.GetDoctorList();
        }
    }
}
