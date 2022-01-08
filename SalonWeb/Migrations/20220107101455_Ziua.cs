using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalonWeb.Migrations
{
    public partial class Ziua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Ziua",
                table: "Programare",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ziua",
                table: "Programare");
        }
    }
}
