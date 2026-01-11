using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class GetPatientsListUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPatientsListUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PatientListItemDto>> ExecuteAsync(
            string? search,
            string? status)
        {
            return await _unitOfWork.Patient.GetPatientsAsync(search, status);
        }
    }
}