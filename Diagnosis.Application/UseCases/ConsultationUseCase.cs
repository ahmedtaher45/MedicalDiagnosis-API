using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagnosis.Domain.Models.Entites;


namespace Diagnosis.Application.UseCases
{
    public class ConsultationUseCase 
    {
        private readonly IConsultationRepository _consultationRepository;

        public ConsultationUseCase(IConsultationRepository consultationRepository)
        {
            _consultationRepository = consultationRepository;
        }
        public async Task<List<ConsultationDTO>> GetDoctorConsultations(int doctorId)
        {
            var configurations =await _consultationRepository.GetByDoctorIdAsync(doctorId);
            return configurations.Select(c => new ConsultationDTO
            {
                Id = c.Id,
                PatientName = c.Patient.FName+ " " + c.Patient.LName,
                PatientBirthDate = c.Patient.BirthDate,
                Type = c.Type.ToString(),
                Symptoms = c.Symptoms,
                Response = c.Notes,
                Status = c.Status.ToString(),
                RquestDate = c.Date
            }).ToList();
        }

        public async Task<ConsultationResponseDTO> AcceptConsultation(int consultationId)
        {
            return await _consultationRepository.AcceptConsultationAsync(consultationId);
        }
        public async Task<ConsultationResponseDTO> RejectConsultation(RejectConsultationDTO rejectConsultationDTO, int consultationId)
        {
            return await _consultationRepository.RejectConsultation(rejectConsultationDTO, consultationId);
        }
        public async Task<ModifyConsultationDTO> GetModifyDataAsync(int consultationId)
        {
            return await _consultationRepository.GetModifyDataAsync(consultationId);
        }
        public async Task<string> ModifyConsultationAsync(ModifyConsultationDTO dto, int consultationId)
        {
            return await _consultationRepository.ModifyConsultationAsync(dto, consultationId);
        }

    }
}