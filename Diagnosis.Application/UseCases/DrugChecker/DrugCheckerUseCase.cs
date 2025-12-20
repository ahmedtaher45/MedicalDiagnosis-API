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
        private readonly IDrugCheckerProvider _drugCheckerProvider;

        public DrugCheckerUseCase(IDrugCheckerProvider drugCheckerProvider)
        {
            _drugCheckerProvider = drugCheckerProvider;
        }

        public async Task<DrugCheckerResponceDTO?> CheckDrugAsync(DrugCheckerRequestDTO requestDTO)
        {
            return await _drugCheckerProvider.CheckDrugAsync(requestDTO);
        }
    }
}