using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    [Authorize(Roles = "Vozac")]
    public class VozacController : BaseController
    {

        public VozacController(CarpoolAppContext db) : base(db)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prikazi()
        {
            List<Models.Vozac> podaci = _db.Vozaci.ToList();

            ViewData["podaci"] = podaci;
            return View();
        }

        public IActionResult Dodaj()
        {
            //uzeti ID Korisnika

            Vozac v = new Vozac();

            return View();
        }

        public IActionResult Obrisi(int VozacID)
        {
            Korisnik k = _db.Korisnici.Find(VozacID);

            TempData["imeVozaca"] = k.Ime + " " + k.Prezime;

            _db.Remove(k);
            _db.SaveChanges();
            return Redirect("/Vozac/Prikazi");
        }

      
    }
}