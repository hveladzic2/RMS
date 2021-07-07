using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class AplikantLokacija_Relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplikanti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KontakTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplikanti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AplikantLokacija",
                columns: table => new
                {
                    AplikantiId = table.Column<int>(type: "int", nullable: false),
                    LokacijeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantLokacija", x => new { x.AplikantiId, x.LokacijeId });
                    table.ForeignKey(
                        name: "FK_AplikantLokacija_Aplikanti_AplikantiId",
                        column: x => x.AplikantiId,
                        principalTable: "Aplikanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantLokacija_Lokacije_LokacijeId",
                        column: x => x.LokacijeId,
                        principalTable: "Lokacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikantLokacija_LokacijeId",
                table: "AplikantLokacija",
                column: "LokacijeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikantLokacija");

            migrationBuilder.DropTable(
                name: "Aplikanti");

            migrationBuilder.DropTable(
                name: "Lokacije");
        }
    }
}
