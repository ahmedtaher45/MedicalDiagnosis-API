using Diagnosis.Application.DTOs.Profile;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.Profile
{
    public class GetDoctorsListUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetDoctorsListUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DoctorListItemDto>> ExecuteAsync(
            string? search,
            bool? isActive)
        {
            return await _unitOfWork.Doctor.GetDoctorsAsync(search, isActive);
        }
    }
}
