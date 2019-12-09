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
        public DbSet<Korisnik> Korisnici { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
