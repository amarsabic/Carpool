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

        [HttpPost]
        public IActionResult Dodaj(AutomobilDodajVM mod)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (mod.Slika != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "imgs");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + mod.Slika.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    mod.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
                }
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

            return RedirectToActionPermanent(nameof(Detalji));
        }

        //public IActionResult Uredi(int automobilID)
        //{
        //    AutomobilUrediVM model = new AutomobilUrediVM();

        //    model = _db.Autmobili.Where(a => a.AutomobilID == automobilID).Select(a => new AutomobilUrediVM
        //    {
        //        BrojRegOznaka=a.BrojRegOznaka,
        //        DatumIstekaRegistracije=a.DatumIstekaRegistracije,
        //        Godiste=a.Godiste,
        //        Model=a.Model,
        //        Naziv=a.Naziv,
        //        AutomobilId=automobilID,
        //        SlikaPath=a.SlikaPath
        //    }).FirstOrDefault();

        //    return View(model);
        //    //return Redirect("/Driver/Automobil/Detalji");          
        //}
        //[HttpPost]
        //public IActionResult Uredi(AutomobilUrediVM mod)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        string uniqueFileName = null;
        //        if (mod.Slika != null)
        //        {
        //            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "imgs");
        //            uniqueFileName = Guid.NewGuid().ToString() + "_" + mod.Slika.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //            mod.Slika.CopyTo(new FileStream(filePath, FileMode.Create));
        //        }

        //        Automobil auto = _db.Autmobili.Find(mod.AutomobilId);

        //        auto.BrojRegOznaka = mod.BrojRegOznaka;
        //        auto.DatumIstekaRegistracije = mod.DatumIstekaRegistracije;
        //        auto.Godiste = mod.Godiste;
        //        auto.Naziv = mod.Naziv;
        //        auto.Model = mod.Model;
                
                
        //        _db.SaveChanges();
        //    }


        //    return Redirect("/Driver/Automobil/Detalji");          
        //}

        public IActionResult Obrisi(int automobilID)
        {
            Automobil auto = _db.Autmobili.Find(automobilID);
            _db.Autmobili.Remove(auto);
            _db.SaveChanges();


            return Redirect(nameof(Detalji));
            //return Redirect("/Driver/Automobil/Detalji");          
        }

    }
}