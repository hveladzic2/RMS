using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresaId",
                table: "ProfilAplikanta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilAplikanta_AdresaId",
                table: "ProfilAplikanta",
                column: "AdresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilAplikanta_Adresa_AdresaId",
                table: "ProfilAplikanta",
                column: "AdresaId",
                principalTable: "Adresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
