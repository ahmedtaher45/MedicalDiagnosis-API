using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddConsultationTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Doctors_DoctorId",
                table: "Consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultation_Patients_PatientId",
                table: "Consultation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultation",
                table: "Consultation");

            migrationBuilder.RenameTable(
                name: "Consultation",
                newName: "Consultations");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_PatientId",
                table: "Consultations",
                newName: "IX_Consultations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultation_DoctorId",
                table: "Consultations",
                newName: "IX_Consultations_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultations",
                table: "Consultations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Doctors_DoctorId",
                table: "Consultations");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultations_Patients_PatientId",
                table: "Consultations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consultations",
                table: "Consultations");

            migrationBuilder.RenameTable(
                name: "Consultations",
                newName: "Consultation");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultation",
                newName: "IX_Consultation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultation",
                newName: "IX_Consultation_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consultation",
                table: "Consultation",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "265279c6-e243-472e-8142-c58956175690", "8055d60e-87fa-4db4-9ed0-ddaca98df853" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "345e8a67-00b1-4ba0-8e36-7f6e1227b8b8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "0a7b9b16-7c14-4c5e-ba7e-5c8673b306db");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Doctors_DoctorId",
                table: "Consultation",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultation_Patients_PatientId",
                table: "Consultation",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
