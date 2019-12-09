using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class izmjenaAutomobilVozac : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobil_Vozac_VozacID",
                table: "Automobil");

            migrationBuilder.DropForeignKey(
                name: "FK_Vozac_AspNetUsers_KorisnikID",
                table: "Vozac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vozac",
                table: "Vozac");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Automobil",
                table: "Automobil");

            migrationBuilder.RenameTable(
                name: "Vozac",
                newName: "Vozaci");

            migrationBuilder.RenameTable(
                name: "Automobil",
                newName: "Autmobili");

            migrationBuilder.RenameIndex(
                name: "IX_Vozac_KorisnikID",
                table: "Vozaci",
                newName: "IX_Vozaci_KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Automobil_VozacID",
                table: "Autmobili",
                newName: "IX_Autmobili_VozacID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vozaci",
                table: "Vozaci",
                column: "VozacID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Autmobili",
                table: "Autmobili",
                column: "AutomobilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Autmobili_Vozaci_VozacID",
                table: "Autmobili",
                column: "VozacID",
                principalTable: "Vozaci",
                principalColumn: "VozacID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozaci_AspNetUsers_KorisnikID",
                table: "Vozaci",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autmobili_Vozaci_VozacID",
                table: "Autmobili");

            migrationBuilder.DropForeignKey(
                name: "FK_Vozaci_AspNetUsers_KorisnikID",
                table: "Vozaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vozaci",
                table: "Vozaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Autmobili",
                table: "Autmobili");

            migrationBuilder.RenameTable(
                name: "Vozaci",
                newName: "Vozac");

            migrationBuilder.RenameTable(
                name: "Autmobili",
                newName: "Automobil");

            migrationBuilder.RenameIndex(
                name: "IX_Vozaci_KorisnikID",
                table: "Vozac",
                newName: "IX_Vozac_KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Autmobili_VozacID",
                table: "Automobil",
                newName: "IX_Automobil_VozacID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vozac",
                table: "Vozac",
                column: "VozacID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Automobil",
                table: "Automobil",
                column: "AutomobilID");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobil_Vozac_VozacID",
                table: "Automobil",
                column: "VozacID",
                principalTable: "Vozac",
                principalColumn: "VozacID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vozac_AspNetUsers_KorisnikID",
                table: "Vozac",
                column: "KorisnikID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
