using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class updateProfilKompanije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "ProfilKompanijaId",
                table: "Lokacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_ProfilKompanijaId",
                table: "Lokacija",
                column: "ProfilKompanijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_ProfilKompanije_ProfilKompanijaId",
                table: "Lokacija",
                column: "ProfilKompanijaId",
                principalTable: "ProfilKompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_ProfilKompanije_ProfilKompanijaId",
                table: "Lokacija");

            migrationBuilder.DropIndex(
                name: "IX_Lokacija_ProfilKompanijaId",
                table: "Lokacija");

            migrationBuilder.DropColumn(
                name: "ProfilKompanijaId",
                table: "Lokacija");

            migrationBuilder.AddColumn<int>(
                name: "AdresaId",
                table: "ProfilKompanije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilKompanije_AdresaId",
                table: "ProfilKompanije",
                column: "AdresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilKompanije_Lokacija_AdresaId",
                table: "ProfilKompanije",
                column: "AdresaId",
                principalTable: "Lokacija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
