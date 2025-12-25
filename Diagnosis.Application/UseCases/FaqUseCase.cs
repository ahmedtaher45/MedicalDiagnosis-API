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
        private readonly IFaq faq;
        public FaqUseCase(IFaq faq)
        {
            this.faq = faq;
        }

        public async Task<List<FaqResponseDTO>> GetAllFaqAsync(string? search = null)
        {
            return await faq.GetAllFaqAsync(search);
        }
    }
}
