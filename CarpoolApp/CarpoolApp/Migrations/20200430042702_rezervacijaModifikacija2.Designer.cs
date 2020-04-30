﻿// <auto-generated />
using System;
using CarpoolApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarpoolApp.Migrations
{
    [DbContext(typeof(CarpoolAppContext))]
    [Migration("20200430042702_rezervacijaModifikacija2")]
    partial class rezervacijaModifikacija2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarpoolApp.Models.Automobil", b =>
                {
                    b.Property<int>("AutomobilID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojRegOznaka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIstekaRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Godiste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAktivan")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SlikaPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VozacID")
                        .HasColumnType("int");

                    b.HasKey("AutomobilID");

                    b.HasIndex("VozacID");

                    b.ToTable("Autmobili");
                });

            modelBuilder.Entity("CarpoolApp.Models.Drzava", b =>
                {
                    b.Property<int>("DrzavaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skracenica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DrzavaID");

                    b.ToTable("Drzave");
                });

            modelBuilder.Entity("CarpoolApp.Models.Grad", b =>
                {
                    b.Property<int>("GradID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DrzavaID")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradID");

                    b.HasIndex("DrzavaID");

                    b.ToTable("Gradovi");
                });

            modelBuilder.Entity("CarpoolApp.Models.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KratkaBiografija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("PreferencijeID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("GradID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PreferencijeID");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CarpoolApp.Models.Muzika", b =>
                {
                    b.Property<int>("MuzikaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KratkiOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zanr")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MuzikaID");

                    b.ToTable("Muzika");
                });

            modelBuilder.Entity("CarpoolApp.Models.Obavijesti", b =>
                {
                    b.Property<int>("ObavijestiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumVrijemeObjave")
                        .HasColumnType("datetime2");

                    b.Property<string>("KratkiOpis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naslov")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipObavijestiID")
                        .HasColumnType("int");

                    b.Property<bool>("Vaznost")
                        .HasColumnType("bit");

                    b.Property<int>("VozacID")
                        .HasColumnType("int");

                    b.HasKey("ObavijestiID");

                    b.HasIndex("TipObavijestiID");

                    b.HasIndex("VozacID");

                    b.ToTable("Obavijesti");
                });

            modelBuilder.Entity("CarpoolApp.Models.Ocjene", b =>
                {
                    b.Property<int>("OcjeneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<int>("TipOcjeneID")
                        .HasColumnType("int");

                    b.Property<int>("VoznjaID")
                        .HasColumnType("int");

                    b.HasKey("OcjeneID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("TipOcjeneID");

                    b.HasIndex("VoznjaID");

                    b.ToTable("Ocjene");
                });

            modelBuilder.Entity("CarpoolApp.Models.Preferencije", b =>
                {
                    b.Property<int>("PreferencijeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Dozvoljene_zivotinje")
                        .HasColumnType("bit");

                    b.Property<bool>("Dozvoljeno_pusenje")
                        .HasColumnType("bit");

                    b.Property<int?>("MuzikaID")
                        .HasColumnType("int");

                    b.HasKey("PreferencijeID");

                    b.HasIndex("MuzikaID");

                    b.ToTable("Preferencije");
                });

            modelBuilder.Entity("CarpoolApp.Models.Prtljag", b =>
                {
                    b.Property<int>("PrtljagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KratkiOpis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PrtljagID");

                    b.ToTable("Prtljag");
                });

            modelBuilder.Entity("CarpoolApp.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("OpisPrtljaga")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsputniGradId")
                        .HasColumnType("int");

                    b.Property<int>("VoznjaID")
                        .HasColumnType("int");

                    b.HasKey("RezervacijaID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("UsputniGradId");

                    b.HasIndex("VoznjaID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("CarpoolApp.Models.TipObavijesti", b =>
                {
                    b.Property<int>("TipObavijestiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NazivTipa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipObavijestiID");

                    b.ToTable("TipObavijesti");
                });

            modelBuilder.Entity("CarpoolApp.Models.TipOcjene", b =>
                {
                    b.Property<int>("TipOcjeneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipOcjeneID");

                    b.ToTable("TipOcjene");
                });

            modelBuilder.Entity("CarpoolApp.Models.UsputniGradovi", b =>
                {
                    b.Property<int>("UsputniGradoviID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CijenaUsputni")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GradID")
                        .HasColumnType("int");

                    b.Property<int>("VoznjaID")
                        .HasColumnType("int");

                    b.HasKey("UsputniGradoviID");

                    b.HasIndex("GradID");

                    b.HasIndex("VoznjaID");

                    b.ToTable("UsputniGradovi");
                });

            modelBuilder.Entity("CarpoolApp.Models.Vozac", b =>
                {
                    b.Property<int>("VozacID")
                        .HasColumnType("int");

                    b.Property<string>("BrVozackeDozvole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumIstekaVozackeDozvole")
                        .HasColumnType("datetime2");

                    b.HasKey("VozacID");

                    b.ToTable("Vozaci");
                });

            modelBuilder.Entity("CarpoolApp.Models.Voznja", b =>
                {
                    b.Property<int>("VoznjaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutomobilID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumObjave")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumPolaska")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradDestinacijaID")
                        .HasColumnType("int");

                    b.Property<int>("GradPolaskaID")
                        .HasColumnType("int");

                    b.Property<decimal>("PunaCijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SlobodnaMjesta")
                        .HasColumnType("int");

                    b.Property<int>("VozacID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VrijemePolaska")
                        .HasColumnType("datetime2");

                    b.HasKey("VoznjaID");

                    b.HasIndex("AutomobilID");

                    b.HasIndex("GradDestinacijaID");

                    b.HasIndex("GradPolaskaID");

                    b.HasIndex("VozacID");

                    b.ToTable("Voznje");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CarpoolApp.Models.Automobil", b =>
                {
                    b.HasOne("CarpoolApp.Models.Vozac", "Vozac")
                        .WithMany("Automobili")
                        .HasForeignKey("VozacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Grad", b =>
                {
                    b.HasOne("CarpoolApp.Models.Drzava", "Drzava")
                        .WithMany("Gradovi")
                        .HasForeignKey("DrzavaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Korisnik", b =>
                {
                    b.HasOne("CarpoolApp.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Preferencije", "Preferencije")
                        .WithMany()
                        .HasForeignKey("PreferencijeID");
                });

            modelBuilder.Entity("CarpoolApp.Models.Obavijesti", b =>
                {
                    b.HasOne("CarpoolApp.Models.TipObavijesti", "TipObavijesti")
                        .WithMany()
                        .HasForeignKey("TipObavijestiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Vozac", "Vozac")
                        .WithMany()
                        .HasForeignKey("VozacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Ocjene", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.TipOcjene", "TipOcjene")
                        .WithMany()
                        .HasForeignKey("TipOcjeneID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Voznja", "Voznja")
                        .WithMany("Ocjene")
                        .HasForeignKey("VoznjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Preferencije", b =>
                {
                    b.HasOne("CarpoolApp.Models.Muzika", "Muzika")
                        .WithMany()
                        .HasForeignKey("MuzikaID");
                });

            modelBuilder.Entity("CarpoolApp.Models.Rezervacija", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", "Korisnik")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.UsputniGradovi", "UsputniGrad")
                        .WithMany()
                        .HasForeignKey("UsputniGradId");

                    b.HasOne("CarpoolApp.Models.Voznja", "Voznja")
                        .WithMany("Rezervacije")
                        .HasForeignKey("VoznjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.UsputniGradovi", b =>
                {
                    b.HasOne("CarpoolApp.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Voznja", "Voznja")
                        .WithMany("UsputniGradovi")
                        .HasForeignKey("VoznjaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Vozac", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", "Korisnik")
                        .WithOne("Vozac")
                        .HasForeignKey("CarpoolApp.Models.Vozac", "VozacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarpoolApp.Models.Voznja", b =>
                {
                    b.HasOne("CarpoolApp.Models.Automobil", "Automobil")
                        .WithMany("Voznje")
                        .HasForeignKey("AutomobilID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Grad", "GradDestinacija")
                        .WithMany()
                        .HasForeignKey("GradDestinacijaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Grad", "GradPolaska")
                        .WithMany()
                        .HasForeignKey("GradPolaskaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Vozac", "Vozac")
                        .WithMany()
                        .HasForeignKey("VozacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarpoolApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("CarpoolApp.Models.Korisnik", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
