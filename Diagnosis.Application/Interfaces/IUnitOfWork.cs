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
        IFaq Faq { get; }
        ISupportTicket SupportTicket { get; }
        IDiagnosisModuleRepository DiagnosisModule { get; }
        IInquiryRepository Inquiry { get; }
        ITreatmentProvider TreatmentProvider { get; }
        IDrugCheckerProvider DrugChecker { get; }
        IConsultationRepository Consultation { get; }
        IProfileRepository Profile { get; }
        IPhysiotherapyExerciseRepository PhysiotherapyExercise { get; }
        ISettingsRepository Settings { get; }
        IAdminDashboardRepository AdminDashboard { get; }
        IDoctorDashboardRepository DoctorDashboard { get; }

        // ✨ New Repositories
        IMedicalFilesRepository MedicalFiles { get; }
        IPatientManagement Patient { get; }
        IDoctorManagement Doctor { get; }
        IDoctorDiagnosisProvider DoctorDiagnosisProvider { get; }INotificationRepository Notifications { get; }


        IMedicalFilesRepository MedicalFiles { get; }
       
        ITreatmentRepository Treatment { get; }
        IUserRepository Users { get; }
        ISystemSettingsRepository systemSettings { get; }



        Task<int> CompleteAsync();
        Task SaveChangesAsync();

       // IAppointmentRepository Appointment { get; }
     
       
    }
}
