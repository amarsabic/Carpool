using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class DatumObjave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumObjave",
                table: "Voznje",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumObjave",
                table: "Voznje");
        }
    }
}
