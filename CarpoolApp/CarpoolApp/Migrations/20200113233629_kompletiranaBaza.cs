using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolApp.Migrations
{
    public partial class kompletiranaBaza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drzave",
                columns: table => new
                {
                    DrzavaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Skracenica = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzave", x => x.DrzavaID);
                });

            migrationBuilder.CreateTable(
                name: "Muzika",
                columns: table => new
                {
                    MuzikaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zanr = table.Column<string>(nullable: true),
                    KratkiOpis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzika", x => x.MuzikaID);
                });

            migrationBuilder.CreateTable(
                name: "Prtljag",
                columns: table => new
                {
                    PrtljagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KratkiOpis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prtljag", x => x.PrtljagID);
                });

            migrationBuilder.CreateTable(
                name: "TipObavijesti",
                columns: table => new
                {
                    TipObavijestiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivTipa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipObavijesti", x => x.TipObavijestiID);
                });

            migrationBuilder.CreateTable(
                name: "TipOcjene",
                columns: table => new
                {
                    TipOcjeneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipOcjene", x => x.TipOcjeneID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gradovi",
                columns: table => new
                {
                    GradID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gradovi", x => x.GradID);
                    table.ForeignKey(
                        name: "FK_Gradovi_Drzave_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzave",
                        principalColumn: "DrzavaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Preferencije",
                columns: table => new
                {
                    PreferencijeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dozvoljeno_pusenje = table.Column<bool>(nullable: false),
                    Dozvoljene_zivotinje = table.Column<bool>(nullable: false),
                    MuzikaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferencije", x => x.PreferencijeID);
                    table.ForeignKey(
                        name: "FK_Preferencije_Muzika_MuzikaID",
                        column: x => x.MuzikaID,
                        principalTable: "Muzika",
                        principalColumn: "MuzikaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    KratkaBiografija = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    GradID = table.Column<int>(nullable: false),
                    PreferencijeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Preferencije_PreferencijeID",
                        column: x => x.PreferencijeID,
                        principalTable: "Preferencije",
                        principalColumn: "PreferencijeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vozaci",
                columns: table => new
                {
                    VozacID = table.Column<int>(nullable: false),
                    BrVozackeDozvole = table.Column<string>(nullable: true),
                    DatumIstekaVozackeDozvole = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vozaci", x => x.VozacID);
                    table.ForeignKey(
                        name: "FK_Vozaci_AspNetUsers_VozacID",
                        column: x => x.VozacID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Autmobili",
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
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autmobili", x => x.AutomobilID);
                    table.ForeignKey(
                        name: "FK_Autmobili_Vozaci_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozaci",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Obavijesti",
                columns: table => new
                {
                    ObavijestiID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KratkiOpis = table.Column<string>(nullable: true),
                    Naslov = table.Column<string>(nullable: true),
                    DatumVrijemeObjave = table.Column<DateTime>(nullable: false),
                    TipObavijestiID = table.Column<int>(nullable: false),
                    Vaznost = table.Column<bool>(nullable: false),
                    VozacID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obavijesti", x => x.ObavijestiID);
                    table.ForeignKey(
                        name: "FK_Obavijesti_TipObavijesti_TipObavijestiID",
                        column: x => x.TipObavijestiID,
                        principalTable: "TipObavijesti",
                        principalColumn: "TipObavijestiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Obavijesti_Vozaci_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozaci",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voznje",
                columns: table => new
                {
                    VoznjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPolaska = table.Column<DateTime>(nullable: false),
                    VrijemePolaska = table.Column<DateTime>(nullable: false),
                    SlobodnaMjesta = table.Column<int>(nullable: false),
                    CijenaPoOsobi = table.Column<double>(nullable: false),
                    VozacID = table.Column<int>(nullable: false),
                    AutomobilID = table.Column<int>(nullable: false),
                    GradPolaskaID = table.Column<int>(nullable: false),
                    GradDestinacijaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voznje", x => x.VoznjaID);
                    table.ForeignKey(
                        name: "FK_Voznje_Autmobili_AutomobilID",
                        column: x => x.AutomobilID,
                        principalTable: "Autmobili",
                        principalColumn: "AutomobilID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voznje_Gradovi_GradDestinacijaID",
                        column: x => x.GradDestinacijaID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Voznje_Gradovi_GradPolaskaID",
                        column: x => x.GradPolaskaID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Voznje_Vozaci_VozacID",
                        column: x => x.VozacID,
                        principalTable: "Vozaci",
                        principalColumn: "VozacID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Ocjene",
                columns: table => new
                {
                    OcjeneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(nullable: true),
                    TipOcjeneID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    VoznjaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocjene", x => x.OcjeneID);
                    table.ForeignKey(
                        name: "FK_Ocjene_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjene_TipOcjene_TipOcjeneID",
                        column: x => x.TipOcjeneID,
                        principalTable: "TipOcjene",
                        principalColumn: "TipOcjeneID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ocjene_Voznje_VoznjaID",
                        column: x => x.VoznjaID,
                        principalTable: "Voznje",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "UsputniGradovi",
                columns: table => new
                {
                    UsputniGradoviID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradPoRedu = table.Column<int>(nullable: false),
                    IndividualnaCijena = table.Column<double>(nullable: false),
                    VoznjaID = table.Column<int>(nullable: false),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsputniGradovi", x => x.UsputniGradoviID);
                    table.ForeignKey(
                        name: "FK_UsputniGradovi_Gradovi_GradID",
                        column: x => x.GradID,
                        principalTable: "Gradovi",
                        principalColumn: "GradID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsputniGradovi_Voznje_VoznjaID",
                        column: x => x.VoznjaID,
                        principalTable: "Voznje",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRezervacije = table.Column<DateTime>(nullable: false),
                    VoznjaID = table.Column<int>(nullable: false),
                    KorisnikID = table.Column<int>(nullable: false),
                    UsputniGradODID = table.Column<int>(nullable: false),
                    UsputniGradoviODUsputniGradoviID = table.Column<int>(nullable: true),
                    UsputniGradDOID = table.Column<int>(nullable: false),
                    UsputniGradoviDOUsputniGradoviID = table.Column<int>(nullable: true),
                    PrtljagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Prtljag_PrtljagID",
                        column: x => x.PrtljagID,
                        principalTable: "Prtljag",
                        principalColumn: "PrtljagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviDOUsputniGradoviID",
                        column: x => x.UsputniGradoviDOUsputniGradoviID,
                        principalTable: "UsputniGradovi",
                        principalColumn: "UsputniGradoviID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_UsputniGradovi_UsputniGradoviODUsputniGradoviID",
                        column: x => x.UsputniGradoviODUsputniGradoviID,
                        principalTable: "UsputniGradovi",
                        principalColumn: "UsputniGradoviID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Voznje_VoznjaID",
                        column: x => x.VoznjaID,
                        principalTable: "Voznje",
                        principalColumn: "VoznjaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GradID",
                table: "AspNetUsers",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PreferencijeID",
                table: "AspNetUsers",
                column: "PreferencijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Autmobili_VozacID",
                table: "Autmobili",
                column: "VozacID");

            migrationBuilder.CreateIndex(
                name: "IX_Gradovi_DrzavaID",
                table: "Gradovi",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijesti_TipObavijestiID",
                table: "Obavijesti",
                column: "TipObavijestiID");

            migrationBuilder.CreateIndex(
                name: "IX_Obavijesti_VozacID",
                table: "Obavijesti",
                column: "VozacID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_KorisnikID",
                table: "Ocjene",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_TipOcjeneID",
                table: "Ocjene",
                column: "TipOcjeneID");

            migrationBuilder.CreateIndex(
                name: "IX_Ocjene_VoznjaID",
                table: "Ocjene",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Preferencije_MuzikaID",
                table: "Preferencije",
                column: "MuzikaID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikID",
                table: "Rezervacije",
                column: "KorisnikID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_VoznjaID",
                table: "Rezervacije",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_UsputniGradovi_GradID",
                table: "UsputniGradovi",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_UsputniGradovi_VoznjaID",
                table: "UsputniGradovi",
                column: "VoznjaID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_AutomobilID",
                table: "Voznje",
                column: "AutomobilID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_GradDestinacijaID",
                table: "Voznje",
                column: "GradDestinacijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_GradPolaskaID",
                table: "Voznje",
                column: "GradPolaskaID");

            migrationBuilder.CreateIndex(
                name: "IX_Voznje_VozacID",
                table: "Voznje",
                column: "VozacID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Obavijesti");

            migrationBuilder.DropTable(
                name: "Ocjene");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TipObavijesti");

            migrationBuilder.DropTable(
                name: "TipOcjene");

            migrationBuilder.DropTable(
                name: "Prtljag");

            migrationBuilder.DropTable(
                name: "UsputniGradovi");

            migrationBuilder.DropTable(
                name: "Voznje");

            migrationBuilder.DropTable(
                name: "Autmobili");

            migrationBuilder.DropTable(
                name: "Vozaci");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Gradovi");

            migrationBuilder.DropTable(
                name: "Preferencije");

            migrationBuilder.DropTable(
                name: "Drzave");

            migrationBuilder.DropTable(
                name: "Muzika");
        }
    }
}
