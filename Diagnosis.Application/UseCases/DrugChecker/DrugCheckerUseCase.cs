using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Application.DTOs.DrugChecker;


namespace Diagnosis.Application.UseCases.DrugChecker
{
    public class DrugCheckerUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DrugCheckerUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DrugCheckerResponceDTO?> CheckDrugAsync(DrugCheckerRequestDTO requestDTO)
        {
            return await _unitOfWork.DrugChecker.CheckDrugAsync(requestDTO);
        }
    }
}