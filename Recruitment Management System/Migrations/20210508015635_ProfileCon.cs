using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class ProfileCon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "ProfilaSlika",
                table: "ProfilAplikanta");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KontakTelefon",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaProfila",
                table: "ProfilAplikanta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilAplikanta_AspNetUsers_UserId",
                table: "ProfilAplikanta");

            migrationBuilder.DropIndex(
                name: "IX_ProfilAplikanta_UserId",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "SlikaProfila",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfilAplikanta");

            migrationBuilder.AlterColumn<string>(
                name: "Prezime",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KontakTelefon",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ime",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilaSlika",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
