using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Infrastracture.Identity;

namespace Diagnosis.Infrastracture.Repositories
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private IJwtTokenGenerator _jwtTokenGenerator;
        

        public UnitOfWork(
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
            Auth = new AuthRepository(_userManager, _jwtTokenGenerator );
        }

        public IAuth Auth { get; private set; }

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
