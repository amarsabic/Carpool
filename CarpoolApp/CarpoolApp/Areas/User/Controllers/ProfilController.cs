using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.User.Controllers
{
   
    
    public class ProfilController : BaseController
    {
        private UserManager<Korisnik> _userManager;
        private RoleManager<IdentityRole<int>> _roleManager;
        private SignInManager<Korisnik> _signInManager;

        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Detalji()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<bool> SnimiVozaca(string BrojVozackeDozvole, DateTime DatumIstekaDozvole)
        {
            Vozac noviVozac = new Vozac
            {
                VozacID = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),
                BrVozackeDozvole = BrojVozackeDozvole,
                DatumIstekaVozackeDozvole = DatumIstekaDozvole
            };
            _db.Vozaci.Add(noviVozac);
           await _db.SaveChangesAsync();


            await _roleManager.CreateAsync(new IdentityRole<int> {Name = "Vozac", NormalizedName = "VOZAC" }); //Kreiranje role u bazi
            var curentUser = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Name)); // Dobavaljas trenutnog logiranog Korisnika
            await _userManager.AddToRoleAsync(curentUser, "Vozac"); //dodavanja role
            await _userManager.RemoveFromRoleAsync(curentUser, "Korisnik");
            await _signInManager.RefreshSignInAsync(curentUser); // refresh logiranog usera na stranici
           
            return true;
        }

        public ProfilController(CarpoolAppContext db,SignInManager<Korisnik> signInManager ,UserManager<Korisnik> userManager,RoleManager<IdentityRole<int>> roleManager) : base(db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
    }

    
}