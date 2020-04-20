﻿using System;
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
        public IActionResult CijenaVoznje(int voznjaID)
        {
            var model = new CijenaVoznjeVM
            {
                rows = _db.UsputniGradovi.Where(u => u.VoznjaID == voznjaID).Select(u => new CijenaVoznjeVM.Row
                {
                    UsputniGradID = u.UsputniGradoviID,
                    UsputniNaziv = u.Grad.Naziv
                }).ToList(),

                GradDestinacija = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => v.GradDestinacija.Naziv).FirstOrDefault(),
                GradPolazak = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => v.GradPolaska.Naziv).FirstOrDefault(),
                VoznjaID = voznjaID
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult CijenaVoznje(CijenaVoznjeVM mod)
        {
            foreach (var item in mod.rows)
            {
                UsputniGradovi usputni = _db.UsputniGradovi.Find(item.UsputniGradID);

                usputni.CijenaUsputni = item.UsputniCijena;
                _db.UsputniGradovi.Update(usputni);
            }


            _db.SaveChanges();


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
                Automobili = _db.Autmobili.Where(a => a.VozacID == vozac && !a.IsAktivan).Select(a => new SelectListItem
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
                PunaCijena = mod.PunaCijena,
                DatumPolaska = mod.DatumPolaska,
                SlobodnaMjesta = mod.SlobodnaMjesta,
                VrijemePolaska = mod.VrijemePolaska,
                VozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                VoznjaID = mod.VoznjaID
            };

            _db.Add(voznja);
            _db.SaveChanges();

            if (mod.SelektiraniGradovi != null)
            {
                foreach (var selektirani in mod.SelektiraniGradovi)
                {
                    UsputniGradovi usputni = new UsputniGradovi
                    {
                        GradID = selektirani,
                        VoznjaID = voznja.VoznjaID
                    };

                    _db.UsputniGradovi.Add(usputni);
                }
            }

            Automobil auto = _db.Autmobili.Find(mod.AutomobilID);
            auto.IsAktivan = true;

            _db.SaveChanges();

            return RedirectToAction("CijenaVoznje", "Voznje", new { voznjaID = voznja.VoznjaID });
        }

        public IActionResult Uredi(int voznjaID)
        {
            int vozac = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Voznja v = _db.Voznje.Where(v => v.VoznjaID == voznjaID).FirstOrDefault();

            VoznjeUrediVM mod = new VoznjeUrediVM
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
                Automobili = _db.Autmobili.Where(a => a.VozacID == vozac && !a.IsAktivan).Select(a => new SelectListItem
                {
                    Value = a.AutomobilID.ToString(),
                    Text = a.Naziv + " " + a.Model
                }).ToList(),
                UsputniGradovi = _db.Gradovi.OrderBy(g => g.Naziv).Select(g => new SelectListItem
                {
                    Value = g.GradID.ToString(),
                    Text = g.Naziv
                }).ToList(),

                PunaCijena = v.PunaCijena,
                VrijemePolaska = v.VrijemePolaska,
                SlobodnaMjesta = v.SlobodnaMjesta,
                DatumPolaska = v.DatumPolaska,
                VozacID = vozac,
                VoznjaID = voznjaID
            };

            return View("Uredi", mod);
        }

        [HttpPost]
        public IActionResult Uredi(VoznjeUrediVM mod)
        {

            Voznja v = _db.Voznje.Find(mod.VoznjaID);

            v.PunaCijena = mod.PunaCijena;
            v.SlobodnaMjesta = mod.SlobodnaMjesta;
            v.DatumPolaska = mod.DatumPolaska;
            v.VrijemePolaska = mod.VrijemePolaska;

            if (mod.GradPolaskaID != 0)
            {
                v.GradPolaskaID = mod.GradPolaskaID;
            }
            if (mod.GradDestinacijaID != 0)
            {
                v.GradDestinacijaID = mod.GradDestinacijaID;
            }
            if (mod.AutomobilID != 0)
            {
                Automobil stari = _db.Autmobili.Find(v.AutomobilID);
                stari.IsAktivan = false;

                v.AutomobilID = mod.AutomobilID;
                Automobil novi = _db.Autmobili.Find(mod.AutomobilID);
                novi.IsAktivan = true;


                _db.Autmobili.Update(novi);
                _db.Autmobili.Update(stari);
            }

            if (mod.SelektiraniGradovi != null)
            {
                var stari = _db.UsputniGradovi.Where(u => u.VoznjaID == v.VoznjaID).ToList();
                foreach (var grad in stari)
                {
                    _db.UsputniGradovi.Remove(grad);
                }

                foreach (var selektirani in mod.SelektiraniGradovi)
                {
                    UsputniGradovi usputni = new UsputniGradovi
                    {
                        GradID = selektirani,
                        VoznjaID = mod.VoznjaID
                    };

                    _db.UsputniGradovi.Add(usputni);
                }
            }

            _db.Voznje.Update(v);
            _db.SaveChanges();

            return RedirectToAction(nameof(Obavijesti));
        }
    }
}