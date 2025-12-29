using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "Diagnosises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientSymptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            
            migrationBuilder.CreateTable(
                name: "ClinicalFindings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalFindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicalFindings_Diagnosises_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SuggestedMedications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Frequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuggestedMedications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuggestedMedications_Diagnosises_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Symptoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiagnosisId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptoms_Diagnosises_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnosises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SupportTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportTickets_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportTickets_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SupportTickets_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrescriptionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrescriptionId = table.Column<int>(type: "int", nullable: false),
                    MedicineName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrescriptionItems_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "Id");
                });


            
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "user-0", 0, "83cff965-e2da-452d-b78f-5e7fa5c1f7a0", "admin@diagnosis.com", true, false, null, "ADMIN@DIAGNOSIS.COM", "ADMIN@DIAGNOSIS.COM", "", null, false, "b10ee2e6-4d76-4a41-9378-5089a2b3d053", false, "admin@diagnosis.com" },
                    { "user-1", 0, "cd2aac68-434e-4fe3-bd02-5c9fa2706959", "doctor@test.com", true, false, null, "DOCTOR@TEST.COM", "DOCTOR@TEST.COM", "", null, false, "stamp1", false, "doctor@test.com" },
                    { "user-2", 0, "1b76410a-7b6b-4a9e-93d8-048b018b9109", "patient@test.com", true, false, null, "PATIENT@TEST.COM", "PATIENT@TEST.COM", "", null, false, "stamp2", false, "patient@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Diagnosises",
                columns: new[] { "Id", "CreatedOn", "Description", "IsDeleted", "ModifiedOn", "Name", "PatientSymptoms", "Title" },
                values: new object[,]
                {
                    { 1, null, "Viral infection affecting upper respiratory tract", false, null, "Upper Respiratory Infection", "Fever, cough, sore throat, runny nose", "Cold & Flu" },
                    { 2, null, "Inflammation of stomach lining", false, null, "Gastritis", "Abdominal pain, nausea, vomiting", "Stomach Pain" },
                    { 3, null, "Chronic elevation of blood pressure", false, null, "High Blood Pressure", "Headache, dizziness, blurred vision", "Hypertension" },
                    { 4, null, "Routine diabetes follow-up and monitoring", false, null, "Type 2 Diabetes Mellitus", "Fatigue, frequent urination", "Diabetes Follow-up" }
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreatedOn", "IsDeleted", "ModifiedOn", "Question", "Type" },
                values: new object[,]
                {
                    { 1, "You can book an appointment through the mobile application.", null, false, null, "How can I book an appointment?", "Patient" },
                    { 2, "Yes, you can cancel or reschedule your appointment from your profile.", null, false, null, "Can I cancel or reschedule my appointment?", "Patient" },
                    { 3, "Your medical history is available in the medical records section.", null, false, null, "How do I view my medical history?", "Patient" },
                    { 4, "Yes, all your data is securely stored and protected.", null, false, null, "Is my personal data secure?", "Patient" },
                    { 5, "You can manage your appointments from the doctor dashboard.", null, false, null, "How can I manage my appointments?", "Doctor" },
                    { 6, "You can update your availability from your profile settings.", null, false, null, "How do I update my availability?", "Doctor" },
                    { 7, "Yes, you can access medical records for patients assigned to you.", null, false, null, "Can I access patient medical records?", "Doctor" },
                    { 8, "Payments are transferred to your registered bank account.", null, false, null, "How do I receive payments?", "Doctor" }
                });

            migrationBuilder.InsertData(
                table: "ClinicalFindings",
                columns: new[] { "Id", "CreatedOn", "DiagnosisId", "IsDeleted", "ModifiedOn", "Name", "Notes", "Value" },
                values: new object[,]
                {
                    { 1, null, 1, false, null, "Body Temperature", "Fever", "38.5°C" },
                    { 2, null, 1, false, null, "Oxygen Saturation", "Normal", "98%" },
                    { 3, null, 2, false, null, "Abdominal tenderness", "Epigastric area", "Present" },
                    { 4, null, 3, false, null, "Blood Pressure", "Elevated", "150/95 mmHg" },
                    { 5, null, 4, false, null, "HbA1c", "Above target", "7.1%" },
                    { 6, null, 4, false, null, "Fasting Blood Glucose", "Elevated", "140 mg/dL" }
                });

            migrationBuilder.InsertData(
                table: "SuggestedMedications",
                columns: new[] { "Id", "CreatedOn", "DiagnosisId", "Dosage", "Frequency", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "500 mg", "Every 8 hours", false, null, "Paracetamol" },
                    { 2, null, 1, "10 mg", "Once daily", false, null, "Antihistamine" },
                    { 3, null, 2, "20 mg", "Once daily before meals", false, null, "Omeprazole" },
                    { 4, null, 2, "10 ml", "After meals", false, null, "Antacid" },
                    { 5, null, 3, "5 mg", "Once daily", false, null, "Amlodipine" },
                    { 6, null, 3, "-", "Low salt diet & exercise", false, null, "Lifestyle modification" },
                    { 7, null, 4, "500 mg", "Twice daily", false, null, "Metformin" }
                });

            migrationBuilder.InsertData(
                table: "Symptoms",
                columns: new[] { "Id", "CreatedOn", "DiagnosisId", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, false, null, "Fever" },
                    { 2, null, 1, false, null, "Cough" },
                    { 3, null, 1, false, null, "Sore throat" },
                    { 4, null, 1, false, null, "Runny nose" },
                    { 5, null, 1, false, null, "Body aches" },
                    { 6, null, 2, false, null, "Abdominal pain" },
                    { 7, null, 2, false, null, "Nausea" },
                    { 8, null, 2, false, null, "Vomiting" },
                    { 9, null, 2, false, null, "Bloating" },
                    { 10, null, 3, false, null, "Headache" },
                    { 11, null, 3, false, null, "Dizziness" },
                    { 12, null, 3, false, null, "Blurred vision" },
                    { 13, null, 4, false, null, "Fatigue" },
                    { 14, null, 4, false, null, "Frequent urination" }
                });

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "ConfidenceLevel", "Date", "Description", "DiagnosisName", "DoctorId", "FileUrls", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "RejectNotes", "RejectReason", "Status", "Symptoms", "Type" },
                values: new object[] { 1, 0, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General inquiry about symptoms", null, -1, null, false, null, "Patient reports symptoms for 3 days.", -1, null, null, "Pending", "Headache, fever, and fatigue.", "Inquiry" });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalFindings_DiagnosisId",
                table: "ClinicalFindings",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_PatientId",
                table: "Prescriptions",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SuggestedMedications_DiagnosisId",
                table: "SuggestedMedications",
                column: "DiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_DoctorId",
                table: "SupportTickets",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_PatientId",
                table: "SupportTickets",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_userId",
                table: "SupportTickets",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_DiagnosisId",
                table: "Symptoms",
                column: "DiagnosisId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "ClinicalFindings");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "LabResults");


            
            migrationBuilder.DropTable(
                name: "SuggestedMedications");

            migrationBuilder.DropTable(
                name: "SupportTickets");

            migrationBuilder.DropTable(
                name: "Symptoms");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Diagnosises");

            migrationBuilder.DropTable(
                name: "Doctors");

        }
    }
}
