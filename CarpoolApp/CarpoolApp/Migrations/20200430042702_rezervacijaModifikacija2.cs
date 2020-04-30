using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class rezervacijaModifikacija2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_UsputniGradId",
                table: "Rezervacije",
                column: "UsputniGradId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradId",
                table: "Rezervacije",
                column: "UsputniGradId",
                principalTable: "UsputniGradovi",
                principalColumn: "UsputniGradoviID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradId",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_UsputniGradId",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradoviID",
                table: "Rezervacije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_UsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviID",
                principalTable: "UsputniGradovi",
                principalColumn: "UsputniGradoviID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
