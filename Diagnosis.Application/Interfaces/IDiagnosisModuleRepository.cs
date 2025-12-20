using Diagnosis.Application.DTOs.DiagnosisModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IDiagnosisModuleRepository
    {
        Task<DiagnosisResponse> CreateDiagnosisAsync(CreateDiagnosisDTO createDiagnosisDTO);
    }
}
