using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class changeFKNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AplikantLokacija_Aplikanti_AplikantiId",
                table: "AplikantLokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_AplikantLokacija_Lokacije_LokacijeId",
                table: "AplikantLokacija");

            migrationBuilder.RenameColumn(
                name: "LokacijeId",
                table: "AplikantLokacija",
                newName: "LokacijaId");

            migrationBuilder.RenameColumn(
                name: "AplikantiId",
                table: "AplikantLokacija",
                newName: "AplikantId");

            migrationBuilder.RenameIndex(
                name: "IX_AplikantLokacija_LokacijeId",
                table: "AplikantLokacija",
                newName: "IX_AplikantLokacija_LokacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AplikantLokacija_Aplikanti_AplikantId",
                table: "AplikantLokacija",
                column: "AplikantId",
                principalTable: "Aplikanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AplikantLokacija_Lokacije_LokacijaId",
                table: "AplikantLokacija",
                column: "LokacijaId",
                principalTable: "Lokacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AplikantLokacija_Aplikanti_AplikantId",
                table: "AplikantLokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_AplikantLokacija_Lokacije_LokacijaId",
                table: "AplikantLokacija");

            migrationBuilder.RenameColumn(
                name: "LokacijaId",
                table: "AplikantLokacija",
                newName: "LokacijeId");

            migrationBuilder.RenameColumn(
                name: "AplikantId",
                table: "AplikantLokacija",
                newName: "AplikantiId");

            migrationBuilder.RenameIndex(
                name: "IX_AplikantLokacija_LokacijaId",
                table: "AplikantLokacija",
                newName: "IX_AplikantLokacija_LokacijeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AplikantLokacija_Aplikanti_AplikantiId",
                table: "AplikantLokacija",
                column: "AplikantiId",
                principalTable: "Aplikanti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AplikantLokacija_Lokacije_LokacijeId",
                table: "AplikantLokacija",
                column: "LokacijeId",
                principalTable: "Lokacije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
