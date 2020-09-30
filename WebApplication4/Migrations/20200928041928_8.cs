using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships",
                column: "reportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships",
                column: "reportId");
        }
    }
}
