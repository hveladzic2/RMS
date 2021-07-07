using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class dropFkOglasiKompanija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "ProfilKompanijeId1",
                table: "OglasiTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
