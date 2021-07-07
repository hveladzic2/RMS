using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class oglasiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LokacijaOglasi");

            migrationBuilder.DropTable(
                name: "OglasiProfilAplikanta");

            migrationBuilder.DropTable(
                name: "Oglasi");

            migrationBuilder.CreateTable(
                name: "OglasiTable",
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
                    table.PrimaryKey("PK_OglasiTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OglasiTable_ProfilKompanije_ProfilKompanijeId1",
                        column: x => x.ProfilKompanijeId1,
                        principalTable: "ProfilKompanije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OglasiTable_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LokacijaOglasiTable",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(type: "int", nullable: false),
                    OglasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LokacijaOglasiTable", x => new { x.LokacijaId, x.OglasId });
                    table.ForeignKey(
                        name: "FK_LokacijaOglasiTable_Lokacija_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LokacijaOglasiTable_OglasiTable_OglasId",
                        column: x => x.OglasId,
                        principalTable: "OglasiTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OglasiTableProfilAplikanta",
                columns: table => new
                {
                    OglasiId = table.Column<int>(type: "int", nullable: false),
                    ProfiliAplikanataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OglasiTableProfilAplikanta", x => new { x.OglasiId, x.ProfiliAplikanataId });
                    table.ForeignKey(
                        name: "FK_OglasiTableProfilAplikanta_OglasiTable_OglasiId",
                        column: x => x.OglasiId,
                        principalTable: "OglasiTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OglasiTableProfilAplikanta_ProfilAplikanta_ProfiliAplikanataId",
                        column: x => x.ProfiliAplikanataId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LokacijaOglasiTable_OglasId",
                table: "LokacijaOglasiTable",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasiTable_ProfilKompanijeId1",
                table: "OglasiTable",
                column: "ProfilKompanijeId1");

            migrationBuilder.CreateIndex(
                name: "IX_OglasiTable_StatusId",
                table: "OglasiTable",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasiTableProfilAplikanta_ProfiliAplikanataId",
                table: "OglasiTableProfilAplikanta",
                column: "ProfiliAplikanataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LokacijaOglasiTable");

            migrationBuilder.DropTable(
                name: "OglasiTableProfilAplikanta");

            migrationBuilder.DropTable(
                name: "OglasiTable");

            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIsteka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Odjel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PocetakPrijave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_LokacijaOglasi_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
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
                        name: "FK_OglasiProfilAplikanta_Oglasi_OglasiId",
                        column: x => x.OglasiId,
                        principalTable: "Oglasi",
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
                name: "IX_Oglasi_ProfilKompanijeId1",
                table: "Oglasi",
                column: "ProfilKompanijeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_StatusId",
                table: "Oglasi",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasiProfilAplikanta_ProfiliAplikanataId",
                table: "OglasiProfilAplikanta",
                column: "ProfiliAplikanataId");
        }
    }
}
