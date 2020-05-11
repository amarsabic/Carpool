using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Rezervacije;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class RezervacijeController : BaseController
    {
        public RezervacijeController(CarpoolAppContext db) : base(db)
        {
        }

        public IActionResult Detalji()
        {
            var model = new RezervacijeDetaljiVM();

           var vozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            model.voznje = _db.Voznje.Where(v => v.VozacID == vozacID && v.IsAktivna).Select(v => new RezervacijeDetaljiVM.Row2
            {
                DatumVoznje = v.DatumPolaska,
                GradPolaska = v.GradPolaska.Naziv,
                GradDestinacija = v.GradDestinacija.Naziv,
                VoznjaID = v.VoznjaID,


                rezervacije = _db.Rezervacije.Where(r => r.VoznjaID == v.VoznjaID).Select(r => new RezervacijeDetaljiVM.Row
                {
                    DatumRezervacije = r.DatumRezervacije,
                    RezervacijaID = r.RezervacijaID,
                    NazivUsputnog = r.UsputniGrad.Grad.Naziv,
                    UsputniCijena = r.UsputniGrad.CijenaUsputni,
                    PunaCijena = v.PunaCijena,
                    ImePutnika=r.Korisnik.Ime + " " + r.Korisnik.Prezime,
                    OpisPrtljaga=r.OpisPrtljaga
                }).ToList()
            }).ToList();


            return View(model);
        }
        public IActionResult PunaRezervacija(int voznjaID)
        {
            PunaRezervacijaVM model = new PunaRezervacijaVM();

            model = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => new PunaRezervacijaVM
            {
                VoznjaID = voznjaID,
                GradDestinacija = v.GradDestinacija.Naziv,
                GradPolaska = v.GradPolaska.Naziv,
                PunaCijena = v.PunaCijena,
                KorisnikID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult PunaRezervacija(PunaRezervacijaVM mod)
        {
            Rezervacija rez = new Rezervacija
            {
                VoznjaID = mod.VoznjaID,
                OpisPrtljaga = mod.OpisPrtljag,
                DatumRezervacije = DateTime.Now,
                KorisnikID = mod.KorisnikID,
                IsAktivna=true
            };

            _db.Rezervacije.Add(rez);

            Voznja v = _db.Voznje.Where(x => x.VoznjaID == mod.VoznjaID).FirstOrDefault();
            v.SlobodnaMjesta--;

            _db.SaveChanges();

            return RedirectToAction("MojaPutovanja");
        }

        public IActionResult UsputniRezervacija(int usputniGradID, int voznjaID)
        {
            UsputniRezervacijaVM model = new UsputniRezervacijaVM();

            model = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => new UsputniRezervacijaVM
            {
                VoznjaID = voznjaID,
                GradDestinacija = v.GradDestinacija.Naziv,
                GradPolaska = v.GradPolaska.Naziv,
                PunaCijena = v.PunaCijena,
                KorisnikID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                UsputniGradID = usputniGradID
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult UsputniRezervacija(UsputniRezervacijaVM mod)
        {
            Rezervacija rez = new Rezervacija
            {
                VoznjaID = mod.VoznjaID,
                OpisPrtljaga = mod.OpisPrtljag,
                DatumRezervacije = DateTime.Now,
                KorisnikID = mod.KorisnikID,
                UsputniGradId = mod.UsputniGradID,
                IsAktivna=true
            };

            _db.Rezervacije.Add(rez);

            Voznja v = _db.Voznje.Where(x => x.VoznjaID == mod.VoznjaID).FirstOrDefault();
            v.SlobodnaMjesta--;

            _db.SaveChanges();

            return RedirectToAction("MojaPutovanja");
        }

        public IActionResult MojaPutovanja()
        {
            var model = new MojaPutovanjaVM();

            var vozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            model.putovanja = _db.Rezervacije.Where(r => r.KorisnikID == vozacID).Select(r => new ViewModels.Rezervacije.MojaPutovanjaVM.Row
            {
                RezervacijaID=r.RezervacijaID,
                Cijena=r.Voznja.PunaCijena,
                UsputniCijena=r.UsputniGrad.CijenaUsputni,
                DatumVoznje=r.Voznja.DatumPolaska,
                GradDestinacija=r.Voznja.GradDestinacija.Naziv,
                GradPolaska=r.Voznja.GradPolaska.Naziv,
                NazivUsputnog=r.UsputniGrad.Grad.Naziv,
                DatumRezervacije=r.DatumRezervacije
            }).ToList();


            return View(model);
        }
    }
}