using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class VozacKorisnikAutomobil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DatumRodjenja",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "KratkaBiografija",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Spol",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vozac",
                columns: table => new
                {
                    VozacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    BrVozackeDozvole = table.Column<string>(nullable: true),
                    DatumIstekaVozackeDozvole = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozac", x => x.VozacID);
                    table.ForeignKey(
                        name: "FK_Vozac_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobil",
                columns: table => new
                {
                    AutomobilID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VozacID = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Godiste = table.Column<string>(nullable: true),
                    BrojRegOznaka = table.Column<string>(nullable: true),
                    DatumIstekaRegistracije = table.Column<DateTime>(nullable: false),
                    Slika = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobil", x => x.AutomobilID);
                    table.ForeignKey(
                        name: "FK_Automobil_Vozac_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozac",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobil_VozacID",
                table: "Automobil",
                column: "VozacID");

            migrationBuilder.CreateIndex(
                name: "IX_Vozac_KorisnikID",
                table: "Vozac",
                column: "KorisnikID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobil");

            migrationBuilder.DropTable(
                name: "Vozac");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DatumRodjenja",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KratkaBiografija",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Spol",
                table: "AspNetUsers");
        }
    }
}
