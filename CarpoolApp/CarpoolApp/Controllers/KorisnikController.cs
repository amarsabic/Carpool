using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarpoolApp.Controllers
{
    public class KorisnikController : Controller
    {
        private readonly CarpoolAppContext _db;

        public KorisnikController(CarpoolAppContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prikazi()
        {
            List<Korisnik> podaci = _db.Korisnici.ToList();

            ViewData["podaci"] = podaci;
            return View();
        }

        public IActionResult Obrisi(int KorisnikID)
        {
            Korisnik k = _db.Korisnici.Find(KorisnikID);

            TempData["imeKorisnika"] = k.Ime + " " + k.Prezime;

            _db.Remove(k);
            _db.SaveChanges();
            return Redirect("/Korisnik/Prikazi");
        }
    }
}