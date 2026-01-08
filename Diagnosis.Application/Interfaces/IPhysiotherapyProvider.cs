using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Entites; 
using Diagnosis.Domain.Models.Entites;
using Microsoft.AspNetCore.Http;
public interface IPhysiotherapyProvider 
{

   Task<AIResponseDto> SubmitPhysiotherapyVideoAsync(IFormFile videoFile, string exerciseName, string userId);
}