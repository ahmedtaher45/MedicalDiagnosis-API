using Diagnosis.Application.DTOs.Inquiry;
using Diagnosis.Application.DTOs.PatientDashboard;
using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.DTOs.Settings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.FileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Application.UseCases.PatientDashboard
{
    public class GetTopSymptomsThisWeekUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetTopSymptomsThisWeekUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TopSymptomsDTO> ExecuteAsync(int patientId)
        {
            return await  _unitOfWork.Consultation.GetTopSymptomsThisWeek(patientId);
        }

    }}
