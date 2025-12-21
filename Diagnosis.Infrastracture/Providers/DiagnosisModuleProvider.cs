using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.Interfaces;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Providers
{
    public class DiagnosisModuleProvider : IDiagnosisModuleProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public DiagnosisModuleProvider(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
        }

        public async Task<ProviderResponse> GetDiagnosisAsync(
            List<(string fileName, byte[] content, string contentType)> files,
            string symptoms,
            string description
            )
        {
            try
            {
                var filesBase64 = files.Select(f =>
                new
                {
                fileName = f.fileName,
                content = Convert.ToBase64String(f.content),
                contentType = f.contentType
                }).ToList();

                var requestBody = new
                {
                    symptoms = symptoms,
                    description = description,
                    files = filesBase64
                };
                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "ai-URL");

                request.Headers.Add("X-API-KEY", _apiKey);

                request.Content = new StringContent(
                    JsonSerializer.Serialize(requestBody),
                    Encoding.UTF8,
                    "application/json");

                var response = await _httpClient.SendAsync(request);


                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<ProviderResponse>();

                if (result == null) throw new Exception("AI API returned null response");

                if (!result.Success) throw new Exception($"AI Diagnosis Failed: {result.Message}");

                return result;
            }
            catch (JsonException ex)
            {
                throw new Exception("Failed to parse AI response. Invalid JSON format.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Failed to connect to AI service.", ex);
            }
            catch (TaskCanceledException ex)
            {
                throw new Exception("AI service request timeout.", ex);
            }
        }
    }
}
