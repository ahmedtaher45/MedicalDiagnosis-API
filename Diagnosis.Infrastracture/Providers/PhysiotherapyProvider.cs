using Diagnosis.Application.DTOs.DiagnosisModule;
using Diagnosis.Application.DTOs.PhysiotherapyExercise;
using Diagnosis.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Providers
{
    public class PhysiotherapyProvider : IPhysiotherapyProvider
{
    private readonly HttpClient _httpClient;

    public PhysiotherapyProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<AIResponseDto> SubmitPhysiotherapyVideoAsync(IFormFile videoFile, string exerciseName, string userId)
    {

        if (videoFile == null || exerciseName == null)
            throw new ArgumentException("Video file and exercise name must be provided.");

        if (!videoFile.FileName.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Video file must be .mp4");

        using var content = new MultipartFormDataContent();
        using var stream = videoFile.OpenReadStream();
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue(videoFile.ContentType);

        content.Add(fileContent, "file", videoFile.FileName);
        content.Add(new StringContent(exerciseName), "exercise");

        var response = await _httpClient.PostAsync("submit_exercise_video", content);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<AIResponseDto>(responseString, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (result == null)
            throw new Exception("AI API returned null response");

        result.Success = true;
        return result;
    }
}

}