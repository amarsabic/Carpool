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
        public IActionResult PunaRezervacija(int voznjaID)
        {
            PunaRezervacijaVM model = new PunaRezervacijaVM();

            model = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => new PunaRezervacijaVM
            {
                VoznjaID=voznjaID,
                GradDestinacija=v.GradDestinacija.Naziv,
                GradPolaska=v.GradPolaska.Naziv,
                PunaCijena=v.PunaCijena,
                KorisnikID= int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        public IActionResult PunaRezervacija(PunaRezervacijaVM mod)
        {
            Rezervacija rez = new Rezervacija
            {
                VoznjaID=mod.VoznjaID,
                OpisPrtljaga=mod.OpisPrtljag,
                DatumRezervacije=DateTime.Now,
                KorisnikID=mod.KorisnikID
            };

            _db.Rezervacije.Add(rez);

            Voznja v = _db.Voznje.Where(x => x.VoznjaID == mod.VoznjaID).FirstOrDefault();
            v.SlobodnaMjesta--;

            _db.SaveChanges();

            return RedirectToAction("MojeRezervacije");
        }
    }
}