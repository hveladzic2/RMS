using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class Oglasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "LokacijaOglas");

            migrationBuilder.DropTable(
                name: "OglasProfilAplikanta");

            migrationBuilder.RenameColumn(
                name: "ProfilKompanijeId",
                table: "Oglas",
                newName: "ProfilKompanijeId1");

            migrationBuilder.RenameIndex(
                name: "IX_Oglas_ProfilKompanijeId",
                table: "Oglas",
                newName: "IX_Oglas_ProfilKompanijeId1");

            migrationBuilder.CreateTable(
                name: "LokacijaOglasi",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(type: "int", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaOglasi", x => new { x.LokacijaId, x.OglasId });
                    table.ForeignKey(
                        name: "FK_LokacijaOglasi_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LokacijaOglasi_Oglas_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OglasiProfilAplikanta",
                columns: table => new
                {
                    OglasiId = table.Column<int>(type: "int", nullable: false),
                    ProfiliAplikanataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasiProfilAplikanta", x => new { x.OglasiId, x.ProfiliAplikanataId });
                    table.ForeignKey(
                        name: "FK_OglasiProfilAplikanta_Oglas_OglasiId",
                        column: x => x.OglasiId,
                        principalTable: "Oglas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OglasiProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId",
                        column: x => x.ProfiliAplikanataId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LokacijaOglasi_OglasId",
                table: "LokacijaOglasi",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasiProfilAplikanta_ProfiliAplikanataId",
                table: "OglasiProfilAplikanta",
                column: "ProfiliAplikanataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Oglas_ProfilKompanije_ProfilKompanijeId1",
                table: "Oglas",
                column: "ProfilKompanijeId1",
                principalTable: "ProfilKompanije",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "LokacijaOglasi");

            migrationBuilder.DropTable(
                name: "OglasiProfilAplikanta");

            migrationBuilder.RenameColumn(
                name: "ProfilKompanijeId1",
                table: "Oglas",
                newName: "ProfilKompanijeId");

            migrationBuilder.RenameIndex(
                name: "IX_Oglas_ProfilKompanijeId1",
                table: "Oglas",
                newName: "IX_Oglas_ProfilKompanijeId");

            migrationBuilder.CreateTable(
                name: "LokacijaOglas",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(type: "int", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaOglas", x => new { x.LokacijaId, x.OglasId });
                    table.ForeignKey(
                        name: "FK_LokacijaOglas_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LokacijaOglas_Oglas_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OglasProfilAplikanta",
                columns: table => new
                {
                    OglasiId = table.Column<int>(type: "int", nullable: false),
                    ProfiliAplikanataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasProfilAplikanta", x => new { x.OglasiId, x.ProfiliAplikanataId });
                    table.ForeignKey(
                        name: "FK_OglasProfilAplikanta_Oglas_OglasiId",
                        column: x => x.OglasiId,
                        principalTable: "Oglas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OglasProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId",
                        column: x => x.ProfiliAplikanataId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LokacijaOglas_OglasId",
                table: "LokacijaOglas",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasProfilAplikanta_ProfiliAplikanataId",
                table: "OglasProfilAplikanta",
                column: "ProfiliAplikanataId");

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
