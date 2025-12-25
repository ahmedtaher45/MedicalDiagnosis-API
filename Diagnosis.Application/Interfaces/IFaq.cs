using Diagnosis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IFaq
    {
        Task<List<FaqResponseDTO>> GetAllFaqAsync(string? search = null);
    }
}
