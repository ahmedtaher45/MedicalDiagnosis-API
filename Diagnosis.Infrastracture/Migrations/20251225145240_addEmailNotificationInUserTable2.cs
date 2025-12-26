using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class addEmailNotificationInUserTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e4394b9e-c40e-4951-ad77-2da4e1123878", "59620394-8756-439d-bf6e-2576914ab610" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "d5ba1350-8b39-4238-be19-2579a8fff10e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "1cff7a3a-d6a5-44a8-8734-6995b608ded5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "669a7124-28d3-402f-9cd3-c368af1a7b3d", "3b308db7-2a4e-40a1-9bab-1c61f7c48f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "db40ad76-9701-4f84-8fad-bbd7d0468299");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "ccaa65b4-0507-42c9-a042-939364bf2323");
        }
    }
}
