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
        IDrugCheckerProvider DrugChecker { get; }
        IConsultationRepository Consultation { get; }
        IProfileRepository Profile { get; }
        IPhysiotherapyExerciseRepository PhysiotherapyExercise { get; }
        ISettingsRepository Settings { get; }
        IAdminDashboardRepository AdminDashboard { get; }
        IDoctorDashboardRepository DoctorDashboard { get; }
        IMedicalFilesRepository MedicalFiles { get; }
        IPatientManagement Patient { get; }
        IDoctorManagement Doctor { get; }
        IDoctorDashboardService DoctorDashboardService { get; }
        INotificationRepository Notifications { get; }      
        ITreatmentRepository Treatment { get; }
        IUserRepository Users { get; }
        ISystemSettingsRepository systemSettings { get; }
        IPatientDashboardRepository PatientDashboard { get; }
        IPhysiotherapyProvider Physiotherapy { get; }



        Task<int> CompleteAsync();
        Task SaveChangesAsync();

       // IAppointmentRepository Appointment { get; }
     
       
    }
}
