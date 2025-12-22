using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Infrastracture.Identity;
using Diagnosis.Application.Services.EmailService;
using Microsoft.Extensions.Configuration;
using Diagnosis.Infrastructure.Providers;
using Diagnosis.Application.Services.FileService;

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
        public UnitOfWork(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator,
            IEmailSender emailSender,
            IDiagnosisModuleRepository diagnosisModule,
            HttpClient httpClient,
            IConfiguration configuration,
            IFileService fileService,
            IDiagnosisModuleProvider diagnosisModuleProvider
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

            Auth = new AuthRepository(_userManager, _jwtTokenGenerator, _emailSender);

            DiagnosisModule = new DiagnosisModuleRepository(_context, _fileService, _diagnosisModuleProvider);
            Inquiry = new InquiryRepository(_context, _fileService);
            Consultation = new ConsultationRepository(_context);
            DrugChecker = new DrugCheckerProvider(_httpClient, _configuration);


        }

        public IAuth Auth { get; private set; }
        public IDiagnosisModuleRepository DiagnosisModule { get; private set; }
        public IConsultationRepository Consultation { get; private set; }
        public IDrugCheckerProvider DrugChecker { get; private set; }
        public IInquiryRepository Inquiry { get; private set; }

       // public IAppointmentRepository Appointment => throw new NotImplementedException();
        public IAppointmentRepository Appointment { get; private set; }

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
