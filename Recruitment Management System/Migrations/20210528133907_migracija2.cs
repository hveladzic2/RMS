using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class migracija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Oglas_OglasId",
                table: "Lokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilAplikanta_Oglas_OglasId",
                table: "ProfilAplikanta");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropIndex(
                name: "IX_ProfilAplikanta_OglasId",
                table: "ProfilAplikanta");

            migrationBuilder.DropIndex(
                name: "IX_Lokacija_OglasId",
                table: "Lokacija");

            migrationBuilder.DropColumn(
                name: "OglasId",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "OglasId",
                table: "Lokacija");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
