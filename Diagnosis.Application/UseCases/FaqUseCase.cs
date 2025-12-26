using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases
{
    public class FaqUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public FaqUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FaqResponseDTO>> GetAllFaqAsync(string? search = null)
        {
            return await _unitOfWork.Faq.GetAllFaqAsync(search);
        }
    }
}
