using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class statuslokacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LokacijaId",
                table: "Status",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Status_LokacijaId",
                table: "Status",
                column: "LokacijaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Lokacija_LokacijaId",
                table: "Status",
                column: "LokacijaId",
                principalTable: "Lokacija",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Lokacija_LokacijaId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_LokacijaId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "LokacijaId",
                table: "Status");
        }
    }
}
