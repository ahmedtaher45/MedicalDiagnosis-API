using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailNotificationInUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ReceiveEmailNotifications",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "ReceiveEmailNotifications", "SecurityStamp" },
                values: new object[] { "669a7124-28d3-402f-9cd3-c368af1a7b3d", true, "3b308db7-2a4e-40a1-9bab-1c61f7c48f09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                columns: new[] { "ConcurrencyStamp", "ReceiveEmailNotifications" },
                values: new object[] { "db40ad76-9701-4f84-8fad-bbd7d0468299", true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                columns: new[] { "ConcurrencyStamp", "ReceiveEmailNotifications" },
                values: new object[] { "ccaa65b4-0507-42c9-a042-939364bf2323", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiveEmailNotifications",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "420c3960-929c-4298-b91c-5fc1aaf6be84", "bd973f8a-9d68-42cf-9ac3-4f4efb2ec6b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "e84a0af2-f6ad-462e-9617-a7f03506f244");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "a7aaf6ae-c0fe-43fd-8677-0b9566bed221");
        }
    }
}
