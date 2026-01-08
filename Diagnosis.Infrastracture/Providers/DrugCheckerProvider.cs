using Diagnosis.Application.DTOs.DrugChecker;
using Diagnosis.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace Diagnosis.Infrastructure.Providers;

public class DrugCheckerProvider : IDrugCheckerProvider
{
    private readonly HttpClient _http;
    private readonly ApplicationDbContext _context;
    public DrugCheckerProvider(HttpClient http, ApplicationDbContext context)
    {
        _http = http;
        _context = context;
    }

    public async Task<DrugCheckerResponceDTO?> CheckDrugAsync(
        DrugCheckerRequestDTO requestDTO)
    {
        if (requestDTO.DrugName == null)
        {
            return new DrugCheckerResponceDTO
            {
                Success = false,
                Message = "Must enter drug name as listed"
            };
        }
        var drug = await _context.Drugs
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.DrugName.ToLower() == requestDTO.DrugName.ToLower());

        if (drug == null)
        {
            return new DrugCheckerResponceDTO
            {
                Success = false,
                Message = "Drug not found in local database"
            };
        }

        var apiRequest = new DrugCheckerApiRequest
        {
            DrugName = drug.DrugName,
            RxOtc = drug.RxOtc,
            DrugClasses = drug.DrugClasses,
            Csa = drug.Csa,
            Alcohol = drug.Alcohol,
            GenericName = drug.GenericName,
            MedicalCondition = drug.MedicalCondition,
            Activity = drug.Activity
        };


        var response = await _http.PostAsJsonAsync("predict", apiRequest);

        if (!response.IsSuccessStatusCode)
        {
            return new DrugCheckerResponceDTO
            {
                Success = false,
                Message = $"API Error: {response.StatusCode}"
            };
        }

        var result =
            await response.Content.ReadFromJsonAsync<DrugCheckerResponce>();

        var risk = await _context.PregnancyRiskCategory.FirstOrDefaultAsync(x => x.Category == result!.PredictedType);
        if (risk == null)
        {
            return new DrugCheckerResponceDTO
            {
                Success = false,
                Message = "No risk for this category"
            };
        }

        return new DrugCheckerResponceDTO
        {
            Success = true,
            RiskLevel = risk.RiskLevel,
            RecommendedAction = risk.RecommendedAction
        };
    }

}
