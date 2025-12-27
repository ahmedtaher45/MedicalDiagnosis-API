using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddHelpTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SupportTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTickets", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "200d2086-35e1-492c-be5f-0ae3016a02cd", "2b2966e6-91b1-4b6d-b079-1f899e3fd893" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "372a132b-c07b-4c7b-ba8d-afc082511200");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "a456e807-17f5-40ff-b6b0-be5ff82dfd8e");

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

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_DoctorId",
                table: "SupportTickets",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportTickets_PatientId",
                table: "SupportTickets",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "SupportTickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "908d365f-b719-4358-8301-b7fa5d7d7933", "205789b7-4e35-43fe-b1fa-bc3d4e2d2ac0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "33105e6c-ae0c-41cb-96b2-250ff9a03641");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "dc327741-d0ea-4975-bdc1-34806340846f");
        }
    }
}
