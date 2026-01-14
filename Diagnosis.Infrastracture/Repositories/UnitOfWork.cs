using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Entites;
using Diagnosis.Application.Services.PdfService;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Providers;
using Diagnosis.Infrastructure.Providers;
using Diagnosis.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender _emailSender;
        private readonly IFileService _fileService;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IDiagnosisModuleProvider _diagnosisModuleProvider;
        private readonly IPhysiotherapyProvider _physiotherapyProvider;
        
        private readonly IPdfService _pdfService;
        public UnitOfWork(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator,
            IEmailSender emailSender,
            HttpClient httpClient,
            IConfiguration configuration,
            IFileService fileService,
            IDiagnosisModuleProvider diagnosisModuleProvider,
            IPhysiotherapyProvider physiotherapyProvider,
           
            IPdfService pdfService
            )
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
            _configuration = configuration;
            _httpClient = httpClient;
            _fileService = fileService;
            _diagnosisModuleProvider = diagnosisModuleProvider;
            _physiotherapyProvider = physiotherapyProvider;
            
            _pdfService = pdfService;

            Auth = new AuthRepository(_userManager, _jwtTokenGenerator, _emailSender, _context);
            
            DiagnosisModule = new DiagnosisModuleRepository(_context, _fileService, _diagnosisModuleProvider);
            Inquiry = new InquiryRepository(_context, _fileService);
            Consultation = new ConsultationRepository(_context);
            DrugChecker = new DrugCheckerProvider(_httpClient, _configuration);
            TreatmentProvider = new TreatmentProvider(_httpClient, _configuration, _context);
            Patient = new PatientRepository(_context);
            Doctor = new DoctorRepository(_context, _userManager);
            DoctorDiagnosisProvider = new DoctorDiagnosisProvider(_httpClient, _configuration, _context);
            // TreatmentProvider = new TreatmentProvider(_httpClient, _configuration, _context);
            Profile = new ProfileRepository(_context);
            PhysiotherapyExercise = new PhysiotherapyExerciseRepository(_context);



            TreatmentProvider = new TreatmentProvider(_httpClient, _configuration, _context);
            AdminDashboard = new AdminDashboardRepository(_context);
            //DoctorDashboard = new DoctorDashboardRepository(_context);
            DoctorDiagnosisProvider = new DoctorDiagnosisProvider(_httpClient, _configuration, _context);
            MedicalFiles = new MedicalFilesRepository(_context);
            Faq = new FaqRepository(_context);
            SupportTicket = new SupportTicketRepository(_context , _userManager);
            Settings  = new SettingsRepository(_context);
            Notifications = new NotificationRepository(_context);
            Patient = new PatientRepository(_context);
            Doctor = new DoctorRepository(_context, _userManager);

            systemSettings = new SystemSettingsRepository(_context , _emailSender);
            Users = new UserRepository(_context , _userManager);


            Profile = new ProfileRepository(_context);
            PhysiotherapyExercise = new PhysiotherapyExerciseRepository(_context);
            Settings = new SettingsRepository(_context);


            Treatment = new TreatmentRepository(_context, _fileService);

            //DoctorDashboardService = new DoctorDashboardService(_context);
            PatientDashboard = new PatientDasboardRepository(_context);
            Physiotherapy = _physiotherapyProvider;
           
           

        }

        public IAuth Auth { get; private set; }
        public IFaq Faq { get; private set; }
        public ISupportTicket SupportTicket { get; private set; }
        public IDiagnosisModuleRepository DiagnosisModule { get; private set; }
        public IConsultationRepository Consultation { get; private set; }
        public IDrugCheckerProvider DrugChecker { get; private set; }
        public IInquiryRepository Inquiry { get; private set; }
        public ITreatmentProvider TreatmentProvider { get; private set; }
        public IProfileRepository Profile { get; private set; }

        public IPhysiotherapyExerciseRepository PhysiotherapyExercise { get; private set; }


        public IAdminDashboardRepository AdminDashboard { get; private set; }

        public IDoctorDashboardRepository DoctorDashboard { get; private set; }

        public IDoctorDiagnosisProvider DoctorDiagnosisProvider { get; private set; }
        public ISettingsRepository Settings { get; private set; }
        public      INotificationRepository Notifications { get; private set; }
        /// <summary>
        /// //
        /// </summary>

        public IMedicalFilesRepository MedicalFiles { get; private set; }

        public IPatientManagement Patient { get; private set; } 
        public IDoctorManagement Doctor { get; private set; }
        public ITreatmentRepository Treatment { get; private set; }

    //public ISystemSetting SystemSetting {  get; private set; }
        public IUserRepository Users { get; private set; }

        public ISystemSettingsRepository systemSettings { get; private set; }

        public IPhysiotherapyProvider Physiotherapy { get; private set; }

      



        public IDoctorDashboardService DoctorDashboardService { get; private set;}

        public IPatientDashboardRepository PatientDashboard { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
