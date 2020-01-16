using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Automobil;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class AutomobilController : BaseController
    {
        public AutomobilController(CarpoolAppContext db) : base(db)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {
            return View(new AutomobilDodajVM());
        }
        public IActionResult Detalji()
        {
            AutomobilDetaljiVM lista = new AutomobilDetaljiVM();
            int vozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            lista.automobili = _db.Autmobili.Where(x => x.VozacID == vozacID)
                .Select(x => new AutomobilDetaljiVM.Row()
                {
                    AutomobilID = x.AutomobilID,
                    Naziv = x.Naziv,
                    Model = x.Model,
                    DatumIstekaRegistracije = x.DatumIstekaRegistracije,
                    BrojRegOznaka = x.BrojRegOznaka,
                    Slika = x.Slika,
                    Godiste = x.Godiste
                })
                .ToList();


            return View(lista);
        }

        [HttpPost]
        public IActionResult Dodaj(AutomobilDodajVM mod)
        {
            Automobil auto = new Automobil()
            {
                VozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                BrojRegOznaka = mod.BrojRegOznaka,
                Godiste = mod.Godiste,
                DatumIstekaRegistracije = mod.DatumIstekaRegistracije,
                Model = mod.Model,
                Naziv = mod.Naziv
            };

            _db.Add(auto);
            _db.SaveChanges();

            return View(new AutomobilDodajVM());
        }

        public IActionResult Obrisi(int automobilID)
        {
            Automobil auto = _db.Autmobili.Find(automobilID);
            _db.Autmobili.Remove(auto);
            _db.SaveChanges();


            return Redirect("/Driver/Automobil/Detalji");
        }
    }
}