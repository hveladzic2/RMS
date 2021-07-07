using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class dodaj_Fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilKompanijeId",
                table: "OglasiTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OglasiTable_ProfilKompanijeId",
                table: "OglasiTable",
                column: "ProfilKompanijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OglasiTable_ProfilKompanije_ProfilKompanijeId",
                table: "OglasiTable",
                column: "ProfilKompanijeId",
                principalTable: "ProfilKompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OglasiTable_ProfilKompanije_ProfilKompanijeId",
                table: "OglasiTable");

            migrationBuilder.DropIndex(
                name: "IX_OglasiTable_ProfilKompanijeId",
                table: "OglasiTable");

            migrationBuilder.DropColumn(
                name: "ProfilKompanijeId",
                table: "OglasiTable");
        }
    }
}
