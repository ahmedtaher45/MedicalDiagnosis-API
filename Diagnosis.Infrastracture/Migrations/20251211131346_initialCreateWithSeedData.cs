using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class initialCreateWithSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "AspNetRoles",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUsers",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //        EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //        TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //        LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //        AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //    },
                //constraints: table =>
                //{
                //    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                //});

            //migrationBuilder.CreateTable(
            //    name: "Clinics",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        City = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Clinics", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetRoleClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserClaims",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserLogins",
            //    columns: table => new
            //    {
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserRoles",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //            column: x => x.RoleId,
            //            principalTable: "AspNetRoles",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "AspNetUserTokens",
            //    columns: table => new
            //    {
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //        table.ForeignKey(
            //            name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Doctors",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ExperienceYears = table.Column<int>(type: "int", nullable: true),
            //        Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //        LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Doctors", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Doctors_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Notifications",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsRead = table.Column<bool>(type: "bit", nullable: false),
            //        RelatedId = table.Column<int>(type: "int", nullable: true),
            //        RelatedType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Notifications", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Notifications_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Patients",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsNewPatient = table.Column<bool>(type: "bit", nullable: false),
            //        IsUrgent = table.Column<bool>(type: "bit", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Patients", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Patients_AspNetUsers_UserId",
            //            column: x => x.UserId,
            //            principalTable: "AspNetUsers",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DoctorClinics",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        ClinicId = table.Column<int>(type: "int", nullable: false),
            //        ConsultationFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        FollowUpFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DoctorClinics", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DoctorClinics_Clinics_ClinicId",
            //            column: x => x.ClinicId,
            //            principalTable: "Clinics",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_DoctorClinics_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Appointments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        AppointmentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AppointmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //        ConsultationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Appointments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Appointments_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Appointments_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Billings",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Billings", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Billings_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LabResults",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ResultValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        ResultStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LabNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LabResults", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LabResults_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_LabResults_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Requests",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        RequestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Requests", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Requests_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Requests_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Payments",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        AppointmentId = table.Column<int>(type: "int", nullable: true),
            //        Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Payments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Payments_Appointments_AppointmentId",
            //            column: x => x.AppointmentId,
            //            principalTable: "Appointments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_Payments_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Prescriptions",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        AppointmentId = table.Column<int>(type: "int", nullable: false),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        DiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Prescriptions", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Prescriptions_Appointments_AppointmentId",
            //            column: x => x.AppointmentId,
            //            principalTable: "Appointments",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Prescriptions_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Prescriptions_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Reviews",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PatientId = table.Column<int>(type: "int", nullable: false),
            //        DoctorId = table.Column<int>(type: "int", nullable: false),
            //        AppointmentId = table.Column<int>(type: "int", nullable: true),
            //        RatingValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Reviews", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Reviews_Appointments_AppointmentId",
            //            column: x => x.AppointmentId,
            //            principalTable: "Appointments",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.SetNull);
            //        table.ForeignKey(
            //            name: "FK_Reviews_Doctors_DoctorId",
            //            column: x => x.DoctorId,
            //            principalTable: "Doctors",
            //            principalColumn: "Id");
            //        table.ForeignKey(
            //            name: "FK_Reviews_Patients_PatientId",
            //            column: x => x.PatientId,
            //            principalTable: "Patients",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PrescriptionItems",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        PrescriptionId = table.Column<int>(type: "int", nullable: false),
            //        MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PrescriptionItems", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
            //            column: x => x.PrescriptionId,
            //            principalTable: "Prescriptions",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
            //    {
            //        { "role-doctor", null, "Doctor", "DOCTOR" },
            //        { "role-patient", null, "Patient", "PATIENT" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[,]
            //    {
            //        { "user-1", 0, "05709cf5-9620-4050-8c56-1a14bad2174d", "doctor@test.com", true, false, null, "DOCTOR@TEST.COM", "DOCTOR@TEST.COM", "", null, false, "stamp1", false, "doctor@test.com" },
            //        { "user-2", 0, "5499f57b-3f1a-4eba-828e-f262e105b762", "patient@test.com", true, false, null, "PATIENT@TEST.COM", "PATIENT@TEST.COM", "", null, false, "stamp2", false, "patient@test.com" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Clinics",
            //    columns: new[] { "Id", "Address", "City", "CreatedOn", "Description", "IsDeleted", "Latitude", "Longitude", "ModifiedOn", "Name", "Phone" },
            //    values: new object[] { -1, "Main Street", "Cairo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General medical services", false, 30.05m, 31.23m, null, "Downtown Clinic", "01012345789" });

            //migrationBuilder.InsertData(
            //    table: "Doctors",
            //    columns: new[] { "Id", "Bio", "CreatedOn", "ExperienceYears", "FName", "IsDeleted", "LName", "LicenseNumber", "ModifiedOn", "ProfileImageUrl", "Rating", "Specialization", "UpdatedAt", "UserId" },
            //    values: new object[] { -1, "Skin specialist", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Ahmed", false, "Mahmoud", "LIC-001", null, "", 4.7m, "Dermatology", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user-1" });

            //migrationBuilder.InsertData(
            //    table: "Notifications",
            //    columns: new[] { "Id", "CreatedOn", "IsDeleted", "IsRead", "Message", "ModifiedOn", "NotificationType", "ReadAt", "RelatedId", "RelatedType", "Title", "UserId", "UserType" },
            //    values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Your appointment is confirmed.", null, "Appointment", null, -1, "Appointment", "Appointment Confirmed", "user-2", "Patient" });

            //migrationBuilder.InsertData(
            //    table: "Patients",
            //    columns: new[] { "Id", "Address", "Allergies", "BloodType", "CreatedOn", "DateOfBirth", "FName", "Gender", "IsDeleted", "IsNewPatient", "IsUrgent", "LName", "ModifiedOn", "ProfileImageUrl", "UpdatedAt", "UserId" },
            //    values: new object[] { -1, "Cairo", "None", "A+", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Female", false, true, false, "Ali", null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user-2" });

            //migrationBuilder.InsertData(
            //    table: "Appointments",
            //    columns: new[] { "Id", "AppointmentDateTime", "AppointmentType", "ConsultationType", "CreatedOn", "DoctorId", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "Status", "UpdatedAt" },
            //    values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "InPerson", "General", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, false, null, "Initial Checkup", -1, "Confirmed", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            //migrationBuilder.InsertData(
            //    table: "Billings",
            //    columns: new[] { "Id", "AmountPaid", "AppointmentDate", "CreatedAt", "CreatedOn", "IsDeleted", "ModifiedOn", "PatientId", "PatientName" },
            //    values: new object[] { -1, 250m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, -1, "Hager" });

            //migrationBuilder.InsertData(
            //    table: "DoctorClinics",
            //    columns: new[] { "Id", "ClinicId", "ConsultationFees", "CreatedOn", "DoctorId", "FollowUpFees", "IsDeleted", "ModifiedOn" },
            //    values: new object[] { -1, -1, 300m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, 150m, false, null });

            //migrationBuilder.InsertData(
            //    table: "LabResults",
            //    columns: new[] { "Id", "CreatedAt", "CreatedOn", "DoctorId", "FileUrl", "IsDeleted", "LabNotes", "ModifiedOn", "PatientId", "ResultStatus", "ResultValue", "TestDate", "TestName" },
            //    values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, "", false, "Good condition", null, -1, "Completed", "Normal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blood Test" });

            //migrationBuilder.InsertData(
            //    table: "Requests",
            //    columns: new[] { "Id", "CreatedOn", "DoctorId", "IsDeleted", "Message", "ModifiedOn", "PatientId", "Priority", "RequestDate", "RequestType", "Status" },
            //    values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, false, "Need urgent follow-up.", null, -1, "High", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "FollowUp", "Pending" });

            //migrationBuilder.InsertData(
            //    table: "Payments",
            //    columns: new[] { "Id", "Amount", "AppointmentId", "CreatedOn", "DoctorId", "IsDeleted", "ModifiedOn", "Notes", "PaymentDate", "PaymentMethod", "PaymentStatus" },
            //    values: new object[] { -1, 300m, -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, false, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid" });

            //migrationBuilder.InsertData(
            //    table: "Prescriptions",
            //    columns: new[] { "Id", "AppointmentId", "CreatedAt", "CreatedOn", "DiagnosisName", "DoctorId", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "Severity", "Specialization" },
            //    values: new object[] { -1, -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Skin Irritation", -1, false, null, "Use cream twice daily", -1, "Mild", "Dermatology" });

            //migrationBuilder.InsertData(
            //    table: "Reviews",
            //    columns: new[] { "Id", "AppointmentId", "CreatedOn", "DoctorId", "IsDeleted", "ModifiedOn", "PatientId", "RatingValue", "ReviewText" },
            //    values: new object[] { -1, -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -1, false, null, -1, 5m, "Excellent doctor!" });

            //migrationBuilder.InsertData(
            //    table: "PrescriptionItems",
            //    columns: new[] { "Id", "CreatedOn", "IsDeleted", "MedicineName", "ModifiedOn", "PrescriptionId" },
            //    values: new object[] { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Skin Cream", null, -1 });

            //migrationBuilder.CreateIndex(
            //    name: "idx_appointment_date",
            //    table: "Appointments",
            //    column: "AppointmentDateTime");

            //migrationBuilder.CreateIndex(
            //    name: "idx_status",
            //    table: "Appointments",
            //    column: "Status");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Appointments_DoctorId",
            //    table: "Appointments",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Appointments_PatientId",
            //    table: "Appointments",
            //    column: "PatientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetRoleClaims_RoleId",
            //    table: "AspNetRoleClaims",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "RoleNameIndex",
            //    table: "AspNetRoles",
            //    column: "NormalizedName",
            //    unique: true,
            //    filter: "[NormalizedName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserClaims_UserId",
            //    table: "AspNetUserClaims",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserLogins_UserId",
            //    table: "AspNetUserLogins",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_AspNetUserRoles_RoleId",
            //    table: "AspNetUserRoles",
            //    column: "RoleId");

            //migrationBuilder.CreateIndex(
            //    name: "EmailIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedEmail");

            //migrationBuilder.CreateIndex(
            //    name: "UserNameIndex",
            //    table: "AspNetUsers",
            //    column: "NormalizedUserName",
            //    unique: true,
            //    filter: "[NormalizedUserName] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "idx_appointment_date",
            //    table: "Billings",
            //    column: "AppointmentDate");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Billings_PatientId",
            //    table: "Billings",
            //    column: "PatientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoctorClinics_ClinicId",
            //    table: "DoctorClinics",
            //    column: "ClinicId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DoctorClinics_DoctorId_ClinicId",
            //    table: "DoctorClinics",
            //    columns: new[] { "DoctorId", "ClinicId" },
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Doctors_UserId",
            //    table: "Doctors",
            //    column: "UserId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_LabResults_DoctorId",
            //    table: "LabResults",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_LabResults_PatientId",
            //    table: "LabResults",
            //    column: "PatientId");

            //migrationBuilder.CreateIndex(
            //    name: "idx_created_at",
            //    table: "Notifications",
            //    column: "CreatedOn");

            //migrationBuilder.CreateIndex(
            //    name: "idx_user_unread",
            //    table: "Notifications",
            //    columns: new[] { "UserId", "IsRead" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Patients_UserId",
            //    table: "Patients",
            //    column: "UserId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "idx_payment_date",
            //    table: "Payments",
            //    column: "PaymentDate");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payments_AppointmentId",
            //    table: "Payments",
            //    column: "AppointmentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Payments_DoctorId",
            //    table: "Payments",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PrescriptionItems_PrescriptionId",
            //    table: "PrescriptionItems",
            //    column: "PrescriptionId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prescriptions_AppointmentId",
            //    table: "Prescriptions",
            //    column: "AppointmentId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prescriptions_DoctorId",
            //    table: "Prescriptions",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Prescriptions_PatientId",
            //    table: "Prescriptions",
            //    column: "PatientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requests_DoctorId",
            //    table: "Requests",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Requests_PatientId",
            //    table: "Requests",
            //    column: "PatientId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_AppointmentId",
            //    table: "Reviews",
            //    column: "AppointmentId",
            //    unique: true,
            //    filter: "[AppointmentId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_DoctorId",
            //    table: "Reviews",
            //    column: "DoctorId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Reviews_PatientId",
            //    table: "Reviews",
            //    column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "AspNetRoleClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserClaims");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserLogins");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserRoles");

            //migrationBuilder.DropTable(
            //    name: "AspNetUserTokens");

            //migrationBuilder.DropTable(
            //    name: "Billings");

            //migrationBuilder.DropTable(
            //    name: "DoctorClinics");

            //migrationBuilder.DropTable(
            //    name: "LabResults");

            //migrationBuilder.DropTable(
            //    name: "Notifications");

            //migrationBuilder.DropTable(
            //    name: "Payments");

            //migrationBuilder.DropTable(
            //    name: "PrescriptionItems");

            //migrationBuilder.DropTable(
            //    name: "Requests");

            //migrationBuilder.DropTable(
            //    name: "Reviews");

            //migrationBuilder.DropTable(
            //    name: "AspNetRoles");

            //migrationBuilder.DropTable(
            //    name: "Clinics");

            //migrationBuilder.DropTable(
            //    name: "Prescriptions");

            //migrationBuilder.DropTable(
            //    name: "Appointments");

            //migrationBuilder.DropTable(
            //    name: "Doctors");

            //migrationBuilder.DropTable(
            //    name: "Patients");

            //migrationBuilder.DropTable(
            //    name: "AspNetUsers");
        }
    }
}
