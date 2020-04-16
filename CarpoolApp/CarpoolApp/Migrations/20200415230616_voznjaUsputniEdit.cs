using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class voznjaUsputniEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaPoOsobi",
                table: "Voznje");

            migrationBuilder.DropColumn(
                name: "GradPoRedu",
                table: "UsputniGradovi");

            migrationBuilder.DropColumn(
                name: "IndividualnaCijena",
                table: "UsputniGradovi");

            migrationBuilder.AddColumn<double>(
                name: "PunaCijena",
                table: "Voznje",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CijenaUsputni",
                table: "UsputniGradovi",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PunaCijena",
                table: "Voznje");

            migrationBuilder.DropColumn(
                name: "CijenaUsputni",
                table: "UsputniGradovi");

            migrationBuilder.AddColumn<double>(
                name: "CijenaPoOsobi",
                table: "Voznje",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "GradPoRedu",
                table: "UsputniGradovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "IndividualnaCijena",
                table: "UsputniGradovi",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
