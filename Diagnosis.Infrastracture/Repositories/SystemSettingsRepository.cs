using Diagnosis.Application.DTOs.SystemSettings;
using Diagnosis.Application.Interfaces;
using Diagnosis.Domain.Models.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnosis.Infrastracture.Repositories
{
    public class SystemSettingsRepository : Repository<UserAIUsage>, ISystemSettingsRepository
    {
        private readonly ApplicationDbContext _context;
        public SystemSettingsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CanUseAiAsync(string userId)
        {
            var maxRequest = await _context.UsageConfig.FirstOrDefaultAsync();
            if (maxRequest == null) throw new NullReferenceException("Must assign max requests" + nameof(maxRequest));

            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var userUsage = await _context.Usages.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userUsage == null)
            {
                await _context.Usages.AddAsync(new UserAIUsage
                {
                    UserId = userId,
                    UsedRequestsToday = 0,
                    LastResetDate = today
                });
            }

            if (userUsage!.LastResetDate != today)
            {
                userUsage.UsedRequestsToday = 0;
                userUsage.LastResetDate = today;
            }

            if (userUsage!.UsedRequestsToday >= maxRequest.MaxRequestsPerDay)
            {
                return false;
            }

            userUsage.UsedRequestsToday++;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UsageResponse> DefineMaxAIRequestPerDay(MaxRequestDTO maxRequestDTO)
        {
            if (maxRequestDTO.maxRequestsPerDay == 0)
            {
                return new UsageResponse
                {
                    Success = false,
                    Message = "Must enter value above 0"
                };
            }
            var maxRequest = await _context.UsageConfig.FirstOrDefaultAsync();
            maxRequest!.MaxRequestsPerDay = maxRequestDTO.maxRequestsPerDay;
            return new UsageResponse
            {
                Success = true,
                Message = "Max Requsts per day for AI Dianosis usage has been updated successfully"
            };
        }

        public async Task<bool> CanMakeDiagnosisAsync(string userId)
        {
            var maxDiagnosis = await _context.UsageConfig.FirstOrDefaultAsync();
            if (maxDiagnosis == null) throw new NullReferenceException("Must assign max requests" + nameof(maxDiagnosis));

            var today = DateOnly.FromDateTime(DateTime.UtcNow);

            var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.UserId == userId);


            if (doctor!.LastResetDate != today)
            {
                doctor.DiagnosisPerDay = 0;
                doctor.LastResetDate = today;
            }

            if (doctor!.DiagnosisPerDay >= maxDiagnosis.MaxDiagnosisPerDay)
            {
                return false;
            }

            doctor.DiagnosisPerDay++;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UsageResponse> DefineMaxDoctorDiagnosisPerDay(MaxRequestDTO maxRequestDTO)
        {
            if (maxRequestDTO.maxRequestsPerDay == 0)
            {
                return new UsageResponse
                {
                    Success = false,
                    Message = "Must enter value above 0"
                };
            }
            var maxRequest = await _context.UsageConfig.FirstOrDefaultAsync();
            maxRequest!.MaxDiagnosisPerDay = maxRequestDTO.maxRequestsPerDay;
            return new UsageResponse
            {
                Success = true,
                Message = "Max Diagnosis per day for doctor has been updated successfully"
            };
        }

        public async Task<bool> IsAiEnabledAsync()
        {
            var enabled = await _context.UsageConfig.FirstOrDefaultAsync();
            if(enabled!.AiEnabled)
            {
                return true;
            }
            return false;
        }

        public async Task<UsageResponse> ToggleAiAsync(EnableAiDTO enableAiDTO)
        {
            if (string.IsNullOrEmpty(enableAiDTO.Enabled.ToString()))
            {
                return new UsageResponse
                {
                    Success = false,
                    Message = "Must enter true or false"
                };
            }

            var enabled = await _context.UsageConfig.FirstOrDefaultAsync();
            enabled!.AiEnabled = enableAiDTO.Enabled;
            await _context.SaveChangesAsync();
            return new UsageResponse
            {
                Success = true,
                Message = "AI services status changed successfully"
            };
        }
    }
}
