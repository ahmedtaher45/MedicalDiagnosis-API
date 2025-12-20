using Diagnosis.Application.DTOs;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites;
using Diagnosis.Domain.Models.Entites;
namespace Diagnosis.Application.UseCases
{
    public class CreateTreatmentUseCase
    {
        private readonly ITreatmentRepository _treatmentRepository;
        private readonly IUnitOfWork _unitOfWork;
       

        public CreateTreatmentUseCase(
            ITreatmentRepository treatmentRepository,
            IUnitOfWork unitOfWork)
            
        {
            _treatmentRepository = treatmentRepository;
            _unitOfWork = unitOfWork;
           
        }

        public async Task<TreatmentDTO> Execute(CreateTreatmentDTO dto)
        {
            // التحقق من البيانات المدخلة
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Treatment name is required");
            // إنشاء العلاج
            var treatment = new Treatment
            {
                Id = 0,
                Name = dto.Name,
                Dosage = dto.Dosage,
                Method = dto.Method,
                Frequency = dto.Frequency,
                TotalDuration = dto.TotalDuration,
                Alternatives = dto.Alternatives,
                PatientId = dto.PatientId,
                IsActive = true,
               // CreatedAt = DateTime.UtcNow
            };
            // حفظ في قاعدة البيانات
            await _treatmentRepository.AddAsync(treatment);
            await _unitOfWork.SaveChangesAsync();

           

            // إرجاع DTO
            return new TreatmentDTO
            {
                Id = treatment.Id,
                Name = treatment.Name,
                Dosage = treatment.Dosage,
                Method = treatment.Method,
                Frequency = treatment.Frequency,
                TotalDuration = treatment.TotalDuration,
                Alternatives = treatment.Alternatives,
                IsActive = treatment.IsActive,
                PatientId = treatment.PatientId,
                
            };
        }
    }
}
