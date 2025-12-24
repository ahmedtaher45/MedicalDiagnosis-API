using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Diagnosis.Infrastructure.Queries;

public class PatientDashboardRepository 
{
    private readonly ApplicationDbContext _context;

    public PatientDashboardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // public async Task<int> GetMedicalFilesCountAsync(string userId)
    // {
        
            
        
    // }
   


    public async Task<int> GetPendingConsultationsAsync(int PatientId) =>
        await _context.Consultations.CountAsync(x => x.PatientId == PatientId && x.Status == Domain.Models.Entites.ConsultationStatus.Pending);

   
   

}