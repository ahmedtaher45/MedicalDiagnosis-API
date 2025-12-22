
using Diagnosis.API.Middleware;
using Diagnosis.Application.Interfaces;
using Diagnosis.Application.Services.EmailService;
using Diagnosis.Application.Services.ProfileService;
using Diagnosis.Application.UseCases;
using Diagnosis.Domain.Models.Entites;
using Diagnosis.Infrastracture.Identity;
using Diagnosis.Infrastracture.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Threading.Tasks;



namespace Diagnosis.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Diagnosis");
            var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            builder.Services.Configure<FormOptions>(O =>
            {
                O.ValueLengthLimit = int.MaxValue;
                O.MultipartBodyLengthLimit = int.MaxValue;
                O.MemoryBufferThreshold = int.MaxValue;
            });
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddDataProtection();

            builder.Services.AddScoped<ChangePasswordUseCase>();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<RegisterUseCase>();
            builder.Services.AddScoped<LoginUseCase>();
            builder.Services.AddScoped<ForgotPasswordUseCase>();
            builder.Services.AddScoped<ResetPasswordUseCase>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Services.AddScoped<IAuth, AuthRepository>();
            ////
            // تسجيل UseCases
            builder.Services.AddScoped<GetAllTreatmentsUseCase>();
            builder.Services.AddScoped<GetTreatmentByIdUseCase>();
            builder.Services.AddScoped<CreateTreatmentUseCase>();
            builder.Services.AddScoped<GetActiveTreatmentsUseCase>();


            /////
            ///// ====== Profiles (Today Work) ======

            // Generic Management Repository
            builder.Services.AddScoped(typeof(IManagementRepository<>), typeof(ManagementRepository<>));

            // Appointment specialized repository (History + Profiles)
            builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

            // Profile Services
            builder.Services.AddScoped<PatientProfileService>();
            builder.Services.AddScoped<DoctorProfileService>();

            builder.Services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;

                // Password settings 
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

                // Lockout settings 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => 
            opt.TokenLifespan = TimeSpan.FromHours(2));

            builder.Services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                var jwtConfig = builder.Configuration.GetSection("Jwt");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig["Issuer"],
                    ValidAudience = jwtConfig["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtConfig["Key"])
                    )
                };
            });    

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await IdentitySeeder.SeedRoles(roleManager);
            }

            app.Run();
        }
    }
}
