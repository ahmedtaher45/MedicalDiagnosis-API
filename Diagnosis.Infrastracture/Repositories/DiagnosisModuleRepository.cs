using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Providers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class DiagnosisModuleRepository : Repository<Consultation> , IDiagnosisModuleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IDiagnosisModuleProvider _provider;

        public DiagnosisModuleRepository(ApplicationDbContext context,
            IFileService fileService,
            IDiagnosisModuleProvider provider) : base(context)
        {
            _context = context;
            _fileService = fileService;
            _provider = provider;
        }

        public async Task<ProviderResponse> CreateDiagnosisAsync(CreateDiagnosisDTO createDiagnosisDTO)
        {
            foreach (var file in createDiagnosisDTO.Files!)
            {
                if (!_fileService.IsValidFile(file))
                {
                    return new ProviderResponse
                    {
                        Success = false,
                        Message = "Files not valid"
                    };
                }
            }
            var fileUrls = await _fileService.UploadMultipleFilesAsync(createDiagnosisDTO.Files);
            
            var Diagnosis = await _provider.GetDiagnosisAsync(
                await ConvertFilesToBytes(createDiagnosisDTO.Files),
                createDiagnosisDTO.Symptoms!,
                createDiagnosisDTO.Description!
            );

            await _context.Consultations.AddAsync(
                new Consultation
                {
                    PatientId = createDiagnosisDTO.PatientId,
                    DoctorId = createDiagnosisDTO.DoctorId,
                    Symptoms = createDiagnosisDTO.Symptoms,
                    Notes = createDiagnosisDTO.Description,
                    Status = ConsultationStatus.Pending,
                    Type = ConsultationType.AIDiagnosis,
                    Date = DateTime.Now,
                    ConfidenceLevel = Diagnosis.ConfidenceLevel,
                    Description = Diagnosis.DiagnosisDescription,
                    FileUrls = fileUrls
                });
            return Diagnosis;
        }

        private async Task<List<(string FileName, byte[] Content, string ContentType)>>
            ConvertFilesToBytes(ICollection<IFormFile>files )
        {
            var filesData = new List<(string, byte[], string)>();

            foreach (var file in files)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);

                filesData.Add((
                    file.FileName,
                    memoryStream.ToArray(),
                    file.ContentType
                ));
            }
            return filesData;
        }
    }
}
