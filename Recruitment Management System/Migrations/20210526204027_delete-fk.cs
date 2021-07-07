using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class deletefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "ProfilKompanijeId",
                table: "Oglas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilKompanijeId",
                table: "Oglas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_ProfilKompanijeId",
                table: "Oglas",
                column: "ProfilKompanijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_ProfilKompanije_ProfilKompanijeId",
                table: "Oglas",
                column: "ProfilKompanijeId",
                principalTable: "ProfilKompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
