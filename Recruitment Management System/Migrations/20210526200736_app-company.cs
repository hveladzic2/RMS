using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class appcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfilKompanijeId",
                table: "Aplikacija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aplikacija_ProfilKompanijeId",
                table: "Aplikacija",
                column: "ProfilKompanijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikacija_ProfilKompanije_ProfilKompanijeId",
                table: "Aplikacija",
                column: "ProfilKompanijeId",
                principalTable: "ProfilKompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikacija_ProfilKompanije_ProfilKompanijeId",
                table: "Aplikacija");

            migrationBuilder.DropIndex(
                name: "IX_Aplikacija_ProfilKompanijeId",
                table: "Aplikacija");

            migrationBuilder.DropColumn(
                name: "ProfilKompanijeId",
                table: "Aplikacija");
        }
    }
}
