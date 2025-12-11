using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class AuthRepository: IAuth
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthRepository(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<string> RegisterAsync(ApplicationUser dtoUser)
        {
            return "aa";
        }
    }
}
