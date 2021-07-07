using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class table_Aplikacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplikacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SlikaProfila = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CVdokument = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Drzava = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivacionoPismo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumRodjenja = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplikacija", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplikacija");
        }
    }
}
