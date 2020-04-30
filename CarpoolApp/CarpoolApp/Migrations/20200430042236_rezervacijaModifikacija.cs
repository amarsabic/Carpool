using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class rezervacijaModifikacija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Prtljag_PrtljagID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_PrtljagID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "PrtljagID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradDOID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradODID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<string>(
                name: "OpisPrtljaga",
                table: "Rezervacije",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradId",
                table: "Rezervacije",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradoviID",
                table: "Rezervacije",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropIndex(
                name: "IX_Rezervacije_UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "OpisPrtljaga",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradId",
                table: "Rezervacije");

            migrationBuilder.DropColumn(
                name: "UsputniGradoviID",
                table: "Rezervacije");

            migrationBuilder.AddColumn<int>(
                name: "PrtljagID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradDOID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradODID",
                table: "Rezervacije",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_PrtljagID",
                table: "Rezervacije",
                column: "PrtljagID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviDOUsputniGradoviID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviODUsputniGradoviID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Prtljag_PrtljagID",
                table: "Rezervacije",
                column: "PrtljagID",
                principalTable: "Prtljag",
                principalColumn: "PrtljagID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviDOUsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviDOUsputniGradoviID",
                principalTable: "UsputniGradovi",
                principalColumn: "UsputniGradoviID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviODUsputniGradoviID",
                table: "Rezervacije",
                column: "UsputniGradoviODUsputniGradoviID",
                principalTable: "UsputniGradovi",
                principalColumn: "UsputniGradoviID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
