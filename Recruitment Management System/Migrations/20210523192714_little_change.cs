using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class little_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "MotivacionoPismo",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MotivacionoPismo",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "ProfilAplikanta");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfilAplikanta",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfilAplikanta_UserId",
                table: "ProfilAplikanta",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilAplikanta_AspNetUsers_UserId",
                table: "ProfilAplikanta",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
