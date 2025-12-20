using Diagnosis.Application.DTOs.Consultation;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.Interfaces
{
    public interface IConsultationRepository: IRepository<Consultation>
    {
    
        Task<List<Consultation>> GetByDoctorIdAsync(int doctorId);
        Task<List<Consultation>> GetByPatientIdAsync(int patientId);
        Task<List<Consultation>> GetByStatusAsync(ConsultationStatus status);
        Task<Consultation?> GetDetailsAsync(int consultationId);
        Task<ConsultationDetailsDTO> GetConsultationDetailsAsync(int consultationId);
        Task<ConsultationResponseDTO> RejectConsultation(RejectConsultationDTO rejectConsultationDTO, int consultationId);
        Task<ModifyConsultationDTO> GetModifyDataAsync(int consultationId);
        Task<ModifyConsultationResponseDTO> ModifyConsultationAsync(ModifyConsultationRequestDTO dto, int consultationId);
        Task<ConsultationResponseDTO> AcceptConsultationAsync(int consultationId);
    }
}