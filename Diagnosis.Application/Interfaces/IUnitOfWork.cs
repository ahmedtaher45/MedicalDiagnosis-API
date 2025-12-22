using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAuth Auth { get; }
        IDiagnosisModuleRepository DiagnosisModule { get; }
        IInquiryRepository Inquiry { get; }

        IDrugCheckerProvider DrugChecker { get; }
        IConsultationRepository Consultation { get; }
        ITreatmentRepository Treatment { get; }
        Task<int> CompleteAsync();
        Task SaveChangesAsync();
    }
}
