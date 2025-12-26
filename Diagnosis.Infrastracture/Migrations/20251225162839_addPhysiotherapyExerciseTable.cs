using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diagnosis.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class addPhysiotherapyExerciseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysiotherapyExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyPart = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationMinutes = table.Column<int>(type: "int", nullable: false),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiotherapyExercises", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "PhysiotherapyExercises",
                columns: new[] { "Id", "BodyPart", "Difficulty", "DurationMinutes", "ThumbnailUrl", "Title", "YoutubeUrl" },
                values: new object[,]
                {
                    { 1, "Back", "Easy", 4, "https://img.youtube.com/vi/4BOTvaRaDjI/hqdefault.jpg", "Back Stretch Exercise", "https://www.youtube.com/watch?v=4BOTvaRaDjI" },
                    { 2, "Back", "Easy", 6, "https://img.youtube.com/vi/DWmGArQBtFI/hqdefault.jpg", "Lower Back Mobility Routine", "https://www.youtube.com/watch?v=DWmGArQBtFI" },
                    { 3, "Shoulder", "Medium", 5, "https://img.youtube.com/vi/1g6L2HkZz9Y/hqdefault.jpg", "Shoulder Strengthening Exercise", "https://www.youtube.com/watch?v=1g6L2HkZz9Y" },
                    { 4, "Shoulder", "Medium", 7, "https://img.youtube.com/vi/PPzD2w6pXyE/hqdefault.jpg", "Rotator Cuff Rehab Exercise", "https://www.youtube.com/watch?v=PPzD2w6pXyE" },
                    { 5, "Legs", "Hard", 6, "https://img.youtube.com/vi/Z8nQXn1pXyE/hqdefault.jpg", "Leg Balance Exercise", "https://www.youtube.com/watch?v=Z8nQXn1pXyE" },
                    { 6, "Legs", "Medium", 5, "https://img.youtube.com/vi/R1rYz6k2KpU/hqdefault.jpg", "Knee Stability Exercise", "https://www.youtube.com/watch?v=R1rYz6k2KpU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysiotherapyExercises");

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
    }
}
