using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApiAppdemo.Migrations
{
    /// <inheritdoc />
    public partial class FirstDataFeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Age",
                columns: new[] { "AgeId", "Age", "DinosaurId", "Name" },
                values: new object[,]
                {
                    { 1011, "Late Jurassic to late creatceous epochs", null, "" },
                    { 1021, "Late Jurassic to late creatceous epochs", null, "" },
                    { 1031, "Late Jurassic to late creatceous epochs", null, "" },
                    { 1041, "Late Jurassic to late creatceous epochs", null, "" },
                    { 1051, "Late Jurassic to late creatceous epochs", null, "" }
                });

            migrationBuilder.InsertData(
                table: "Dinosaurs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 101, "", "Pterodactyl" },
                    { 102, "", "Stegosaurus" },
                    { 103, "", "Ankylosaurus" },
                    { 104, "", "T-Rex" },
                    { 105, "", "Megalosaurus" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Age",
                keyColumn: "AgeId",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "Age",
                keyColumn: "AgeId",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "Age",
                keyColumn: "AgeId",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "Age",
                keyColumn: "AgeId",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "Age",
                keyColumn: "AgeId",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Dinosaurs",
                keyColumn: "Id",
                keyValue: 105);
        }
    }
}
