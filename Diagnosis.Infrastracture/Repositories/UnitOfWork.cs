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

namespace Diagnosis.Infrastracture.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailSender _emailSender;
        private IConsultationRepository _consultationRepository;
        

        public UnitOfWork(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator,
            IEmailSender emailSender,
            IConsultationRepository consultationRepository
            
            )
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailSender = emailSender;
           // _consultationRepository = consultationRepository;

            Auth = new AuthRepository(_userManager, _jwtTokenGenerator , _emailSender);
            Consultation = new ConsultationRepository(_context);
        }

        public IAuth Auth { get; private set; }
        public IConsultationRepository Consultation { get; private set; }

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
