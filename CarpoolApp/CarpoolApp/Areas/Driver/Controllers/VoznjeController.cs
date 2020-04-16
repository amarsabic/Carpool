using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Voznje;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class VoznjeController : BaseController
    {
        public VoznjeController(CarpoolAppContext db) : base(db)
        {
        }
        public IActionResult MojeVoznje()
        {


            return View();
        }
        public IActionResult Dodaj()
        {
            int vozac = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var model = new VoznjeDodajVM
            {
                GradPolaska = _db.Gradovi.OrderBy(g => g.Naziv).Select(g => new SelectListItem
                {
                    Value = g.GradID.ToString(),
                    Text = g.Naziv
                }).ToList(),
                GradDestinacija = _db.Gradovi.OrderBy(g => g.Naziv).Select(g => new SelectListItem
                {
                    Value = g.GradID.ToString(),
                    Text = g.Naziv
                }).ToList(),
                Automobili = _db.Autmobili.Where(a => a.VozacID == vozac).Select(a => new SelectListItem
                {
                    Value = a.AutomobilID.ToString(),
                    Text = a.Naziv + " " + a.Model
                }).ToList(),
                UsputniGradovi = _db.Gradovi.OrderBy(g => g.Naziv).Select(g => new SelectListItem
                {
                    Value = g.GradID.ToString(),
                    Text = g.Naziv
                }).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Dodaj(VoznjeDodajVM mod)
        {
            Voznja voznja = new Voznja
            {
                GradPolaskaID = mod.GradPolaskaID,
                GradDestinacijaID = mod.GradDestinacijaID,
                AutomobilID = mod.AutomobilID,
                PunaCijena = mod.CijenaPoOsobi,
                DatumPolaska = mod.DatumPolaska,
                SlobodnaMjesta = mod.SlobodnaMjesta,
                VrijemePolaska = mod.VrijemePolaska,
                VozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };

            _db.Add(voznja);
            _db.SaveChanges();

            foreach (var selektirani in mod.SelektiraniGradovi)
            {
                UsputniGradovi usputni = new UsputniGradovi
                {
                    GradID=selektirani,
                    VoznjaID=voznja.VoznjaID
                };

                _db.UsputniGradovi.Add(usputni);
            }

            _db.SaveChanges();

            return RedirectToAction(nameof(MojeVoznje));
        }
    }
}