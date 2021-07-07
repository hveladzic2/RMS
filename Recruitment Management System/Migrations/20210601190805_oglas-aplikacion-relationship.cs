using Microsoft.EntityFrameworkCore.Migrations;

namespace Recruitment_Management_System.Migrations
{
    public partial class oglasaplikacionrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<int>(
                name: "oglasId",
                table: "Aplikacija",
                type: "int",
                nullable: true);

          

            migrationBuilder.CreateIndex(
                name: "IX_Aplikacija_oglasId",
                table: "Aplikacija",
                column: "oglasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikacija_OglasiTable_oglasId",
                table: "Aplikacija",
                column: "oglasId",
                principalTable: "OglasiTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
        }
    }
}
