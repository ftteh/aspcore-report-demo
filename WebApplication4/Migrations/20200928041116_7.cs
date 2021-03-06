﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication4.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_userId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_userId",
                table: "Readerships",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Readerships_userId",
                table: "Readerships");

            migrationBuilder.CreateIndex(
                name: "IX_Readerships_userId",
                table: "Readerships",
                column: "userId",
                unique: true);
        }
    }
}
