using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class migracij2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LokacijaOglasi_Oglas_OglasId",
                table: "LokacijaOglasi");

            migrationBuilder.DropForeignKey(
                name: "FK_OglasiProfilAplikanta_Oglas_OglasiId",
                table: "OglasiProfilAplikanta");

            migrationBuilder.AddColumn<int>(
                name: "OglasId",
                table: "ProfilAplikanta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OglasId",
                table: "Lokacija",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Odjel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PocetakPrijave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumIsteka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilKompanijeId1 = table.Column<int>(type: "int", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglasi_ProfilKompanije_ProfilKompanijeId1",
                        column: x => x.ProfilKompanijeId1,
                        principalTable: "ProfilKompanije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oglasi_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfilAplikanta_OglasId",
                table: "ProfilAplikanta",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacija_OglasId",
                table: "Lokacija",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_ProfilKompanijeId1",
                table: "Oglasi",
                column: "ProfilKompanijeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_StatusId",
                table: "Oglasi",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lokacija_Oglas_OglasId",
                table: "Lokacija",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LokacijaOglasi_Oglasi_OglasId",
                table: "LokacijaOglasi",
                column: "OglasId",
                principalTable: "Oglasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OglasiProfilAplikanta_Oglasi_OglasiId",
                table: "OglasiProfilAplikanta",
                column: "OglasiId",
                principalTable: "Oglasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilAplikanta_Oglas_OglasId",
                table: "ProfilAplikanta",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lokacija_Oglas_OglasId",
                table: "Lokacija");

            migrationBuilder.DropForeignKey(
                name: "FK_LokacijaOglasi_Oglasi_OglasId",
                table: "LokacijaOglasi");

            migrationBuilder.DropForeignKey(
                name: "FK_OglasiProfilAplikanta_Oglasi_OglasiId",
                table: "OglasiProfilAplikanta");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfilAplikanta_Oglas_OglasId",
                table: "ProfilAplikanta");

            migrationBuilder.DropTable(
                name: "Oglasi");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LokacijaOglasi_Oglas_OglasId",
                table: "LokacijaOglasi",
                column: "OglasId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OglasiProfilAplikanta_Oglas_OglasiId",
                table: "OglasiProfilAplikanta",
                column: "OglasiId",
                principalTable: "Oglas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
