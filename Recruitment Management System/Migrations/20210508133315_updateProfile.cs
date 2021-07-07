using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class updateProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ulica",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "Ulica",
                table: "ProfilAplikanta");
        }
    }
}
