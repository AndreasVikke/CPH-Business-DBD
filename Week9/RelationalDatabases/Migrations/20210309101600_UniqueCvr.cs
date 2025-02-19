﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RelationalDatabases.Migrations
{
    public partial class UniqueCvr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "cvr",
                table: "vets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vets_cvr",
                table: "vets",
                column: "cvr",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vets_cvr",
                table: "vets");

            migrationBuilder.AlterColumn<string>(
                name: "cvr",
                table: "vets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
