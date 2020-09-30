using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class _111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Reports_reportid",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_reportid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "reportid",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Reports",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Userid",
                table: "Reports",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_Userid",
                table: "Reports",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_Userid",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Userid",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "reportid",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_reportid",
                table: "Users",
                column: "reportid");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Reports_reportid",
                table: "Users",
                column: "reportid",
                principalTable: "Reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
