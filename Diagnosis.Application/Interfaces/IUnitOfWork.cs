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
        ITreatmentProvider TreatmentProvider { get; }
        IDrugCheckerProvider DrugChecker { get; }
        IConsultationRepository Consultation { get; }
        IProfileRepository Profile { get; }
       // IAppointmentRepository Appointment { get; }
     
       
    }
}
