using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class Oglas_Table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KontaktTelefon",
                table: "ProfilAdministratora");

            migrationBuilder.RenameColumn(
                name: "RadnoMjesto",
                table: "Oglas",
                newName: "Pozicija");

            migrationBuilder.AddColumn<string>(
                name: "Odjel",
                table: "Oglas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odjel",
                table: "Oglas");

            migrationBuilder.RenameColumn(
                name: "Pozicija",
                table: "Oglas",
                newName: "RadnoMjesto");

            migrationBuilder.AddColumn<string>(
                name: "KontaktTelefon",
                table: "ProfilAdministratora",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
