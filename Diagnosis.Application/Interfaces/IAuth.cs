using Diagnosis.Application.DTOs;
using Diagnosis.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IAuth
    {
        Task<RegisterResponse> RegisterAsync(ApplicationUser user);
    }
}
