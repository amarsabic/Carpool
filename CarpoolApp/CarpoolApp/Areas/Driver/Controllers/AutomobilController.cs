using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Automobil;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class AutomobilController : BaseController
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        public AutomobilController(CarpoolAppContext db, IWebHostEnvironment hostingEnvironment) : base(db)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {
            return View(new AutomobilDodajVM());
        }
        
        [HttpPost]
        public IActionResult Dodaj(AutomobilDodajVM mod)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = slikaRootFolder(mod);
                Automobil auto = new Automobil()
                {
                    VozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                    BrojRegOznaka = mod.BrojRegOznaka,
                    Godiste = mod.Godiste,
                    DatumIstekaRegistracije = mod.DatumIstekaRegistracije,
                    Model = mod.Model,
                    Naziv = mod.Naziv,
                    SlikaPath = uniqueFileName
                };

                _db.Add(auto);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Detalji));
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
                    Slika = x.SlikaPath,
                    Godiste = x.Godiste
                })
                .ToList();


            return View(lista);
        }
     
        public IActionResult Uredi(int automobilID)
        {
            Automobil a = _db.Autmobili.Find(automobilID);
            AutomobilUrediVM model = new AutomobilUrediVM
            {
                AutomobilId = a.AutomobilID,
                Naziv = a.Naziv,
                Model = a.Model,
                BrojRegOznaka = a.BrojRegOznaka,
                DatumIstekaRegistracije = a.DatumIstekaRegistracije,
                Godiste = a.Godiste,
                PostojecaSlikaPath = a.SlikaPath
            };

            return View("Uredi", model);
        }
        [HttpPost]
        public IActionResult Uredi(AutomobilUrediVM mod)
        {

            if (ModelState.IsValid)
            {
                Automobil auto = _db.Autmobili.Find(mod.AutomobilId);
                auto.BrojRegOznaka = mod.BrojRegOznaka;
                auto.DatumIstekaRegistracije = mod.DatumIstekaRegistracije;
                auto.Godiste = mod.Godiste;
                auto.Naziv = mod.Naziv;
                auto.Model = mod.Model;

                if (mod.Slika != null)
                {
                    if (mod.PostojecaSlikaPath != null)
                    {
                        string putanjaSlike = Path.Combine(hostingEnvironment.WebRootPath, "imgs", mod.PostojecaSlikaPath);
                        System.IO.File.Delete(putanjaSlike);
                    }
                    auto.SlikaPath = slikaRootFolder(mod);
                }

                _db.Autmobili.Update(auto);
                _db.SaveChanges();
            }

            return RedirectToAction(nameof(Detalji));
        }

        private string slikaRootFolder(AutomobilDodajVM mod)
        {
            string uniqueFileName = null;
            if (mod.Slika != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "imgs");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + mod.Slika.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStraem= new FileStream(filePath, FileMode.Create))
                {
                    mod.Slika.CopyTo(fileStraem);
                }
            }

            return uniqueFileName;
        }

        public IActionResult Obrisi(int automobilID)
        {
            Automobil auto = _db.Autmobili.Find(automobilID);

            var aktivnaVoznjaAutomobil = _db.Voznje.Where(v=>v.AutomobilID==automobilID).FirstOrDefault();

            if (aktivnaVoznjaAutomobil == null)
            {
                _db.Autmobili.Remove(auto);
                _db.SaveChanges();
            }

            return Redirect(nameof(Detalji));
            //return Redirect("/Driver/Automobil/Detalji");          
        }

    }
}