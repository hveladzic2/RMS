using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class DBModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplikantLokacija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lokacije",
                table: "Lokacije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aplikanti",
                table: "Aplikanti");

            migrationBuilder.RenameTable(
                name: "Lokacije",
                newName: "Adresa");

            migrationBuilder.RenameTable(
                name: "Aplikanti",
                newName: "ProfilAplikanta");

            migrationBuilder.AddColumn<int>(
                name: "AdresaId",
                table: "ProfilAplikanta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilaSlika",
                table: "ProfilAplikanta",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdresaAplikanta",
                table: "Adresa",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfilAplikanta",
                table: "ProfilAplikanta",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Lokacija",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ulica = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdresaKompanije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obrazovanje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zvanje = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StepenCertifikata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NazivObrazovneInstitucije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Drzava = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilAplikantaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obrazovanje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obrazovanje_ProfilAplikanta_ProfilAplikantaId",
                        column: x => x.ProfilAplikantaId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadnoIskustvo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RadnaPozicija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumPocetka = table.Column<int>(type: "int", nullable: false),
                    DatumZavrsetka = table.Column<int>(type: "int", nullable: false),
                    ProfilAplikantaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadnoIskustvo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadnoIskustvo_ProfilAplikanta_ProfilAplikantaId",
                        column: x => x.ProfilAplikantaId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisniAtribut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vjestine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vjestina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivoPoznavanja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilAplikantaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vjestine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vjestine_ProfilAplikanta_ProfilAplikantaId",
                        column: x => x.ProfilAplikantaId,
                        principalTable: "ProfilAplikanta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfilKompanije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Misija = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    
                    tTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSiteURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilKompanije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilKompanije_AdresaKompanije_AdresaId",
                        column: x => x.AdresaId,
                        principalTable: "Lokacija",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oglas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RadnoMjesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DodatneInformacije = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PocetakPrijave = table.Column<int>(type: "int", nullable: false),
                    DatumIsteka = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    ProfilKompanijeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglas_ProfilKompanije_ProfilKompanijeId",
                        column: x => x.ProfilKompanijeId,
                        principalTable: "ProfilKompanije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oglas_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_ProfilAplikanta_AdresaId",
                table: "ProfilAplikanta",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Obrazovanje_ProfilAplikantaId",
                table: "Obrazovanje",
                column: "ProfilAplikantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_ProfilKompanijeId",
                table: "Oglas",
                column: "ProfilKompanijeId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglas_StatusId",
                table: "Oglas",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OglasProfilAplikanta_ProfiliAplikanataId",
                table: "OglasProfilAplikanta",
                column: "ProfiliAplikanataId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilKompanije_AdresaId",
                table: "ProfilKompanije",
                column: "AdresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RadnoIskustvo_ProfilAplikantaId",
                table: "RadnoIskustvo",
                column: "ProfilAplikantaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vjestine_ProfilAplikantaId",
                table: "Vjestine",
                column: "ProfilAplikantaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfilAplikanta_AdresaAplikanta_AdresaId",
                table: "ProfilAplikanta",
                column: "AdresaId",
                principalTable: "Adresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfilAplikanta_AdresaAplikanta_AdresaId",
                table: "ProfilAplikanta");

            migrationBuilder.DropTable(
                name: "Obrazovanje");

            migrationBuilder.DropTable(
                name: "OglasProfilAplikanta");

            migrationBuilder.DropTable(
                name: "RadnoIskustvo");

            migrationBuilder.DropTable(
                name: "Vjestine");

            migrationBuilder.DropTable(
                name: "Oglas");

            migrationBuilder.DropTable(
                name: "ProfilKompanije");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Lokacija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfilAplikanta",
                table: "ProfilAplikanta");

            migrationBuilder.DropIndex(
                name: "IX_ProfilAplikanta_AdresaId",
                table: "ProfilAplikanta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdresaAplikanta",
                table: "Adresa");

            migrationBuilder.DropColumn(
                name: "AdresaId",
                table: "ProfilAplikanta");

            migrationBuilder.DropColumn(
                name: "ProfilaSlika",
                table: "ProfilAplikanta");

            migrationBuilder.RenameTable(
                name: "ProfilAplikanta",
                newName: "Aplikanti");

            migrationBuilder.RenameTable(
                name: "Adresa",
                newName: "Lokacije");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aplikanti",
                table: "Aplikanti",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lokacije",
                table: "Lokacije",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AplikantLokacija",
                columns: table => new
                {
                    AplikantId = table.Column<int>(type: "int", nullable: false),
                    LokacijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplikantLokacija", x => new { x.AplikantId, x.LokacijaId });
                    table.ForeignKey(
                        name: "FK_AplikantLokacija_Aplikanti_AplikantId",
                        column: x => x.AplikantId,
                        principalTable: "Aplikanti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplikantLokacija_Lokacije_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplikantLokacija_LokacijaId",
                table: "AplikantLokacija",
                column: "LokacijaId");
        }
    }
}
