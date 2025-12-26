using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class addCancelStatusInConsultation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d100a610-d9f3-4f9f-bb7c-b12e923061e3", "565e1c36-b590-4a82-9158-d8e908d77396" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "0101303c-fb2f-404c-a357-11986bb28222");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "f5f0cebd-42aa-4820-87fc-94214a73176f");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b63401d8-990f-4e14-8f37-92a62d726a62", "95ba99b1-f805-41ff-b31b-84bcb4a7c439" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-1",
                column: "ConcurrencyStamp",
                value: "7c54d488-8765-4b5c-a00f-2ef3f3f3faa8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-2",
                column: "ConcurrencyStamp",
                value: "dbeda1f8-ec14-458a-bc1b-dd26cf10a623");
        }
    }
}
