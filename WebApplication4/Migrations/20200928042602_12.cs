using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships");

            migrationBuilder.DropIndex(
                name: "IX_Readerships_userId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships",
                column: "reportId");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_userId",
                table: "Readerships",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships");

            migrationBuilder.DropIndex(
                name: "IX_Readerships_userId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_reportId",
                table: "Readerships",
                column: "reportId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_userId",
                table: "Readerships",
                column: "userId",
                unique: true);
        }
    }
}
