using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Controllers
{
    public class VozacController : Controller
    {
        private readonly CarpoolAppContext _db;

        public VozacController(CarpoolAppContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prikazi()
        {
            List<Vozac> podaci = _db.Vozaci.ToList();

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