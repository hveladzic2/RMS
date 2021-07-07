using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KontakTelefon",
                table: "ProfilAplikanta",
                newName: "KontaktTelefon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KontaktTelefon",
                table: "ProfilAplikanta",
                newName: "KontakTelefon");
        }
    }
}
