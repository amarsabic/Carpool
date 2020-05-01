using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class voznjaIsAktivna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAktivna",
                table: "Voznje",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAktivna",
                table: "Voznje");
        }
    }
}
