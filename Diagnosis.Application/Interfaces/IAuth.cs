using Diagnosis.Application.DTOs;
using Diagnosis.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Application.DTOs;
 
namespace Diagnosis.Application.Interfaces
{
    public interface IAuth
    {
        Task<RegisterResponse> RegisterAsync(ApplicationUser user);
        Task<LoginResponseDTO> LoginAsync(string email, string password, string role);
    }
}
