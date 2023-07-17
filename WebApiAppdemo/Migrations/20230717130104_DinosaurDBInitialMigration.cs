using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAppdemo.Migrations
{
    /// <inheritdoc />
    public partial class DinosaurDBInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dinosaurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinosaurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Age",
                columns: table => new
                {
                    AgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinosaurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Age", x => x.AgeId);
                    table.ForeignKey(
                        name: "FK_Age_Dinosaurs_DinosaurId",
                        column: x => x.DinosaurId,
                        principalTable: "Dinosaurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgeDto",
                columns: table => new
                {
                    AgeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DinosaurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeDto", x => x.AgeId);
                    table.ForeignKey(
                        name: "FK_AgeDto_Dinosaurs_DinosaurId",
                        column: x => x.DinosaurId,
                        principalTable: "Dinosaurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Age_DinosaurId",
                table: "Age",
                column: "DinosaurId");

            migrationBuilder.CreateIndex(
                name: "IX_AgeDto_DinosaurId",
                table: "AgeDto",
                column: "DinosaurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Age");

            migrationBuilder.DropTable(
                name: "AgeDto");

            migrationBuilder.DropTable(
                name: "Dinosaurs");
        }
    }
}
