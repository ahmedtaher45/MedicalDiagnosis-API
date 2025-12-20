using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultationSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "38b5cdd1-6d8d-464d-8af2-89935d3ff808", "b1cc9aaf-c29b-478c-8fcf-fea45d6e101c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "a81e07f4-78e1-43d4-98aa-5658b5c4aad4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "6f4ff980-0c40-4e05-aff2-84b0ac217c9e");

            migrationBuilder.InsertData(
                table: "Consultations",
                columns: new[] { "Id", "ConfidenceLevel", "CreatedOn", "Date", "Description", "DoctorId", "FileUrls", "IsDeleted", "ModifiedOn", "Notes", "PatientId", "RejectNotes", "RejectReason", "Status", "Symptoms", "Type" },
                values: new object[] { 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "General inquiry about symptoms", -1, null, false, null, "Patient reports symptoms for 3 days.", -1, null, null, "Pending", "Headache, fever, and fatigue.", "Inquiry" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Consultations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d7dddb25-13c5-4e71-8640-a4c3fb85b71b", "d8e0f22d-e0f5-4076-8707-0df2a6f0ff59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "dd6001c4-7eb8-4879-8c99-1c6a2f77bb16");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "5cde5de3-207c-4c26-8680-e700b497764a");
        }
    }
}
