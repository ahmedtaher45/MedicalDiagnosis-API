using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //     name: "AspNetRoles",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetUsers",
            //     columns: table => new
            //     {
            //         Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
            //         EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
            //         TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
            //         LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
            //         AccessFailedCount = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetRoleClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetUserClaims",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserClaims_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetUserLogins",
            //     columns: table => new
            //     {
            //         LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserLogins_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetUserRoles",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
            //             column: x => x.RoleId,
            //             principalTable: "AspNetRoles",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //         table.ForeignKey(
            //             name: "FK_AspNetUserRoles_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "AspNetUserTokens",
            //     columns: table => new
            //     {
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
            //         Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
            //         table.ForeignKey(
            //             name: "FK_AspNetUserTokens_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id",
            //             onDelete: ReferentialAction.Cascade);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Doctors",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //         FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ExperienceYears = table.Column<int>(type: "int", nullable: true),
            //         Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
            //         LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Doctors", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Doctors_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Notifications",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //         UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         IsRead = table.Column<bool>(type: "bit", nullable: false),
            //         RelatedId = table.Column<int>(type: "int", nullable: true),
            //         RelatedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Notifications", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Notifications_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Patients",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
            //         FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         BloodType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ProfileImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         IsNewPatient = table.Column<bool>(type: "bit", nullable: true),
            //         IsUrgent = table.Column<bool>(type: "bit", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Patients", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Patients_AspNetUsers_UserId",
            //             column: x => x.UserId,
            //             principalTable: "AspNetUsers",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Payments",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         DoctorId = table.Column<int>(type: "int", nullable: false),
            //         AppointmentId = table.Column<int>(type: "int", nullable: true),
            //         Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //         PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Payments", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Payments_Doctors_DoctorId",
            //             column: x => x.DoctorId,
            //             principalTable: "Doctors",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Consultations",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         PatientId = table.Column<int>(type: "int", nullable: false),
            //         DoctorId = table.Column<int>(type: "int", nullable: false),
            //         Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //         Date = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         ConfidenceLevel = table.Column<int>(type: "int", nullable: false),
            //         FileUrls = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         RejectReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         RejectNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Consultations", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Consultations_Doctors_DoctorId",
            //             column: x => x.DoctorId,
            //             principalTable: "Doctors",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FK_Consultations_Patients_PatientId",
            //             column: x => x.PatientId,
            //             principalTable: "Patients",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "LabResults",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         PatientId = table.Column<int>(type: "int", nullable: false),
            //         DoctorId = table.Column<int>(type: "int", nullable: false),
            //         TestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         TestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //         ResultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ResultStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         LabNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_LabResults", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_LabResults_Doctors_DoctorId",
            //             column: x => x.DoctorId,
            //             principalTable: "Doctors",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FK_LabResults_Patients_PatientId",
            //             column: x => x.PatientId,
            //             principalTable: "Patients",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "Prescriptions",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         AppointmentId = table.Column<int>(type: "int", nullable: false),
            //         PatientId = table.Column<int>(type: "int", nullable: false),
            //         Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DiagnosisName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         Severity = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         DoctorId = table.Column<int>(type: "int", nullable: false),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Prescriptions", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Prescriptions_Doctors_DoctorId",
            //             column: x => x.DoctorId,
            //             principalTable: "Doctors",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FK_Prescriptions_Patients_PatientId",
            //             column: x => x.PatientId,
            //             principalTable: "Patients",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "PrescriptionItems",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         PrescriptionId = table.Column<int>(type: "int", nullable: false),
            //         MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
            //         ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
            //         IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_PrescriptionItems", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
            //             column: x => x.PrescriptionId,
            //             principalTable: "Prescriptions",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[,]
            //     {
            //         { "role-admin", null, "Admin", "ADMIN" },
            //         { "role-doctor", null, "Doctor", "DOCTOR" },
            //         { "role-patient", null, "Patient", "PATIENT" }
            //     });

            // migrationBuilder.InsertData(
            //     table: "AspNetUsers",
            //     columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //     values: new object[,]
            //     {
            //         { "user-0", 0, "420c3960-929c-4298-b91c-5fc1aaf6be84", "admin@diagnosis.com", true, false, null, "ADMIN@DIAGNOSIS.COM", "ADMIN@DIAGNOSIS.COM", "", null, false, "bd973f8a-9d68-42cf-9ac3-4f4efb2ec6b5", false, "admin@diagnosis.com" },
            //         { "user-1", 0, "e84a0af2-f6ad-462e-9617-a7f03506f244", "doctor@test.com", true, false, null, "DOCTOR@TEST.COM", "DOCTOR@TEST.COM", "", null, false, "stamp1", false, "doctor@test.com" },
            //         { "user-2", 0, "a7aaf6ae-c0fe-43fd-8677-0b9566bed221", "patient@test.com", true, false, null, "PATIENT@TEST.COM", "PATIENT@TEST.COM", "", null, false, "stamp2", false, "patient@test.com" }
            //     });

            // migrationBuilder.InsertData(
            //     table: "Doctors",
            //     columns: new[] { "Id", "Bio", "ExperienceYears", "FName", "IsDeleted", "LName", "LicenseNumber", "ModifiedOn", "ProfileImageUrl", "Rating", "Specialization", "UserId" },
            //     values: new object[] { -1, "Skin specialist", 8, "Ahmed", false, "Mahmoud", "LIC-001", null, "", 4.7m, "Dermatology", "user-1" });

            // migrationBuilder.InsertData(
            //     table: "Notifications",
            //     columns: new[] { "Id", "IsDeleted", "IsRead", "Message", "ModifiedOn", "NotificationType", "ReadAt", "RelatedId", "RelatedType", "Title", "UserId", "UserType" },
            //     values: new object[] { -1, false, false, "Your appointment is confirmed.", null, "Appointment", null, -1, "Appointment", "Appointment Confirmed", "user-2", "Patient" });

            // migrationBuilder.InsertData(
            //     table: "Patients",
            //     columns: new[] { "Id", "Address", "Allergies", "BloodType", "DateOfBirth", "FName", "Gender", "IsDeleted", "IsNewPatient", "IsUrgent", "LName", "ModifiedOn", "ProfileImageUrl", "UserId" },
            //     values: new object[] { -1, "Cairo", "None", "A+", new DateTime(1996, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara", "Female", false, true, false, "Ali", null, "", "user-2" });

            // migrationBuilder.InsertData(
            //     table: "Consultations",
            //     columns: new[] { "Id", "ConfidenceLevel", "Date", "Description", "DiagnosisName", "DoctorId", "FileUrls", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "RejectNotes", "RejectReason", "Status", "Symptoms", "Type" },
            //     values: new object[] { 1, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General inquiry about symptoms", null, -1, null, false, null, "Patient reports symptoms for 3 days.", -1, null, null, "Pending", "Headache, fever, and fatigue.", "Inquiry" });

            // migrationBuilder.InsertData(
            //     table: "LabResults",
            //     columns: new[] { "Id", "DoctorId", "FileUrl", "IsDeleted", "LabNotes", "ModifiedOn", "PatientId", "ResultStatus", "ResultValue", "TestDate", "TestName" },
            //     values: new object[] { -1, -1, "", false, "Good condition", null, -1, "Completed", "Normal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blood Test" });

            // migrationBuilder.InsertData(
            //     table: "Payments",
            //     columns: new[] { "Id", "Amount", "AppointmentId", "DoctorId", "IsDeleted", "ModifiedOn", "Notes", "PaymentDate", "PaymentMethod", "PaymentStatus" },
            //     values: new object[] { -1, 300m, -1, -1, false, null, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid" });

            // migrationBuilder.InsertData(
            //     table: "Prescriptions",
            //     columns: new[] { "Id", "AppointmentId", "DiagnosisName", "DoctorId", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "Severity", "Specialization" },
            //     values: new object[] { -1, -1, "Skin Irritation", -1, false, null, "Use cream twice daily", -1, "Mild", "Dermatology" });

            // migrationBuilder.InsertData(
            //     table: "PrescriptionItems",
            //     columns: new[] { "Id", "IsDeleted", "MedicineName", "ModifiedOn", "PrescriptionId" },
            //     values: new object[] { -1, false, "Skin Cream", null, -1 });

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetRoleClaims_RoleId",
            //     table: "AspNetRoleClaims",
            //     column: "RoleId");

            // migrationBuilder.CreateIndex(
            //     name: "RoleNameIndex",
            //     table: "AspNetRoles",
            //     column: "NormalizedName",
            //     unique: true,
            //     filter: "[NormalizedName] IS NOT NULL");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserClaims_UserId",
            //     table: "AspNetUserClaims",
            //     column: "UserId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserLogins_UserId",
            //     table: "AspNetUserLogins",
            //     column: "UserId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_AspNetUserRoles_RoleId",
            //     table: "AspNetUserRoles",
            //     column: "RoleId");

            // migrationBuilder.CreateIndex(
            //     name: "EmailIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedEmail");

            // migrationBuilder.CreateIndex(
            //     name: "UserNameIndex",
            //     table: "AspNetUsers",
            //     column: "NormalizedUserName",
            //     unique: true,
            //     filter: "[NormalizedUserName] IS NOT NULL");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Consultations_DoctorId",
            //     table: "Consultations",
            //     column: "DoctorId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Consultations_PatientId",
            //     table: "Consultations",
            //     column: "PatientId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Doctors_UserId",
            //     table: "Doctors",
            //     column: "UserId",
            //     unique: true,
            //     filter: "[UserId] IS NOT NULL");

            // migrationBuilder.CreateIndex(
            //     name: "IX_LabResults_DoctorId",
            //     table: "LabResults",
            //     column: "DoctorId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_LabResults_PatientId",
            //     table: "LabResults",
            //     column: "PatientId");

            // migrationBuilder.CreateIndex(
            //     name: "idx_created_at",
            //     table: "Notifications",
            //     column: "CreatedOn");

            // migrationBuilder.CreateIndex(
            //     name: "idx_user_unread",
            //     table: "Notifications",
            //     columns: new[] { "UserId", "IsRead" });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Patients_UserId",
            //     table: "Patients",
            //     column: "UserId",
            //     unique: true,
            //     filter: "[UserId] IS NOT NULL");

            // migrationBuilder.CreateIndex(
            //     name: "idx_payment_date",
            //     table: "Payments",
            //     column: "PaymentDate");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Payments_DoctorId",
            //     table: "Payments",
            //     column: "DoctorId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_PrescriptionItems_PrescriptionId",
            //     table: "PrescriptionItems",
            //     column: "PrescriptionId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Prescriptions_DoctorId",
            //     table: "Prescriptions",
            //     column: "DoctorId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Prescriptions_PatientId",
            //     table: "Prescriptions",
            //     column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "AspNetRoleClaims");

            // migrationBuilder.DropTable(
            //     name: "AspNetUserClaims");

            // migrationBuilder.DropTable(
            //     name: "AspNetUserLogins");

            // migrationBuilder.DropTable(
            //     name: "AspNetUserRoles");

            // migrationBuilder.DropTable(
            //     name: "AspNetUserTokens");

            // migrationBuilder.DropTable(
            //     name: "Consultations");

            // migrationBuilder.DropTable(
            //     name: "LabResults");

            // migrationBuilder.DropTable(
            //     name: "Notifications");

            // migrationBuilder.DropTable(
            //     name: "Payments");

            // migrationBuilder.DropTable(
            //     name: "PrescriptionItems");

            // migrationBuilder.DropTable(
            //     name: "AspNetRoles");

            // migrationBuilder.DropTable(
            //     name: "Prescriptions");

            // migrationBuilder.DropTable(
            //     name: "Doctors");

            // migrationBuilder.DropTable(
            //     name: "Patients");

            // migrationBuilder.DropTable(
            //     name: "AspNetUsers");
        }
    }
}
