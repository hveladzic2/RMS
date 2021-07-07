using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class addedNewRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "ProfilKompanije",
                newName: "KontaktEmail");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProfilKompanije",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfilAdministratora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KontaktTelefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SlikaProfila = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilAdministratora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilAdministratora_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfilKompanije_UserId",
                table: "ProfilKompanije",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilAdministratora_UserId",
                table: "ProfilAdministratora",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilKompanije_AspNetUsers_UserId",
                table: "ProfilKompanije",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilKompanije_AspNetUsers_UserId",
                table: "ProfilKompanije");

            migrationBuilder.DropTable(
                name: "ProfilAdministratora");

            migrationBuilder.DropIndex(
                name: "IX_ProfilKompanije_UserId",
                table: "ProfilKompanije");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProfilKompanije");

            migrationBuilder.RenameColumn(
                name: "KontaktEmail",
                table: "ProfilKompanije",
                newName: "Email");
        }
    }
}
