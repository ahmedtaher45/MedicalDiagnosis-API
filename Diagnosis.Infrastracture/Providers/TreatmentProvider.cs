// using Diagnosis.Application.DTOs.DiagnosisModule;
// using Diagnosis.Application.DTOs.Treatment;
// using Diagnosis.Application.Interfaces;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net.Http.Json;
// using System.Text;
// using System.Text.Json;
// using System.Threading.Tasks;

// namespace Diagnosis.Infrastracture.Providers
// {
//     public class TreatmentProvider: ITreatmentProvider
//     {
//         private readonly HttpClient _httpClient;
//         private readonly string _apiKey;
//         private readonly ApplicationDbContext _context;
//         public TreatmentProvider(HttpClient httpClient, 
//             IConfiguration config, 
//             ApplicationDbContext context)
//         {
//             _httpClient = httpClient;
//             _apiKey = config["AiModule:ApiKey"];
//             _context = context;
//         }

//         public async Task<AITreatmentResponseDTO> CreateTreamentPlanAsync(int DiagnosisId)
//         {
//             var inquiry = await _context.Inquiries.FirstOrDefaultAsync(c => c.Id == DiagnosisId);

//             if(inquiry == null)
//             {
//                 return new AITreatmentResponseDTO
//                 {
//                     Success = false, 
//                     Message = "Inquiry Id is incorrect"
//                 };
//             }
//             var createTreatmentDTO = new
//             {
//                 DiagnosisName = inquiry.DiagnosisName,
//                 //DiagnosisDescription = inquiry.Description,
//                 ConfidenceLevel = inquiry.ConfidenceLevel
//             };
//             var request = new HttpRequestMessage(
//                             HttpMethod.Post,
//                             "ai-URL");

//             request.Headers.Add("X-API-KEY", _apiKey);

//             request.Content = new StringContent(
//                 JsonSerializer.Serialize(createTreatmentDTO),
//                 Encoding.UTF8,
//                 "application/json");

//             var response = await _httpClient.SendAsync(request);


//             response.EnsureSuccessStatusCode();

//             var result = await response.Content.ReadFromJsonAsync<AITreatmentResponseDTO>();

//             if (result == null) throw new Exception("AI API returned null response");

//             if (!result.Success) throw new Exception($"AI Treatment Failed: {result.Message}");

//             return result;
//         }
//     }
// }
