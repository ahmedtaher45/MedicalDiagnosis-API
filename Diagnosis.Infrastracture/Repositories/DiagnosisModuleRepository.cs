using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class DiagnosisModuleRepository : IDiagnosisModuleRepository
    {
        private readonly IRepository<Consultation> _repository;

        public DiagnosisModuleRepository(IRepository<Consultation> repository)
        {
            _repository = repository;
        }

        public Task<DiagnosisResponse> CreateDiagnosisAsync(CreateDiagnosisDTO createDiagnosisDTO)
        {
            throw new NotImplementedException();
        }
    }
}
