using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class automobilAktivan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAktivan",
                table: "Autmobili",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAktivan",
                table: "Autmobili");
        }
    }
}
