using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumASPMVC.Migrations
{
    public partial class SeedTopics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Created", "Description", "Title" },
                values: new object[] { 1, null, "Discussion about school", "School" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Created", "Description", "Title" },
                values: new object[] { 2, null, "Discussion about film", "Film" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Created", "Description", "Title" },
                values: new object[] { 3, null, "Discussion about sport", "Sport" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Topics",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
