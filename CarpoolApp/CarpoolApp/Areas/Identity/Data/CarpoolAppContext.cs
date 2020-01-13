using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarpoolApp.Models
{
    public class CarpoolAppContext : IdentityDbContext<Korisnik,IdentityRole<int>, int>
    {
        public CarpoolAppContext(DbContextOptions<CarpoolAppContext> options)
            : base(options)
        {
        }


        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Automobil> Autmobili { get; set; }
        public DbSet<Vozac> Vozaci { get; set; }
        public DbSet<Muzika> Muzika { get; set; }
        public DbSet<Obavijesti> Obavijesti { get; set; }
        public DbSet<Ocjene> Ocjene { get; set; }
        public DbSet<Preferencije> Preferencije { get; set; }
        public DbSet<Prtljag> Prtljag { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<TipObavijesti> TipObavijesti { get; set; }
        public DbSet<TipOcjene> TipOcjene { get; set; }
        public DbSet<UsputniGradovi> UsputniGradovi { get; set; }
        public DbSet<Voznja> Voznje { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }





        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Vozac>()
                .HasOne(s => s.Korisnik)
                .WithOne(ad => ad.Vozac);
        }
    }
}
