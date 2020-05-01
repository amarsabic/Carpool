using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Voznje;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class VoznjeController : BaseController
    {
        public VoznjeController(CarpoolAppContext db) : base(db)
        {
        }

        public IActionResult Detalji()
        {
            return View();
        }
        public IActionResult SveVoznje()
        {
            SveVoznjeVM model = new SveVoznjeVM();

            model.CurrentUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            model.voznje = _db.Voznje
                .Where(a=>a.SlobodnaMjesta>0)
                .OrderByDescending(v => v.DatumObjave).Select(v => new SveVoznjeVM.Row
            {
                AutoNazivModel = v.Automobil.Naziv + " " + v.Automobil.Model,
                SlikaPath = v.Automobil.SlikaPath,
                DatumPolaska = v.DatumPolaska,
                VrijemePolaska = v.VrijemePolaska,
                PunaCijena = v.PunaCijena,
                SlobodnaMjesta = v.SlobodnaMjesta,
                GradPolaska = v.GradPolaska.Naziv,
                GradDestinacija = v.GradDestinacija.Naziv,
                KorisnikID=v.VozacID,

                usputni = _db.UsputniGradovi.Where(u => u.VoznjaID == v.VoznjaID).Select(u => new SveVoznjeVM.Usputni
                {
                    UsputniGradId = u.UsputniGradoviID,
                    Cijena = u.CijenaUsputni,
                    Naziv = u.Grad.Naziv
                }).ToList(),

                VoznjaID = v.VoznjaID,
                KorisnickoIme = v.Vozac.Korisnik.Ime + " " + v.Vozac.Korisnik.Prezime
            }).ToList();

            return View(model);
        }

        public IActionResult SearchVoznje(int odredisteId, int polazisteId)
        {
            SveVoznjeVM model = new SveVoznjeVM();

            model.voznje = _db.Voznje
                .Where(v => (v.GradPolaskaID == polazisteId && v.GradDestinacijaID == odredisteId) || (v.UsputniGradovi.Any(a => a.GradID == odredisteId) && v.GradPolaskaID == polazisteId))
                .OrderByDescending(v => v.DatumObjave).Select(v => new SveVoznjeVM.Row
                {
                    AutoNazivModel = v.Automobil.Naziv + " " + v.Automobil.Model,
                    SlikaPath = v.Automobil.SlikaPath,
                    DatumPolaska = v.DatumPolaska,
                    VrijemePolaska = v.VrijemePolaska,
                    PunaCijena = v.PunaCijena,
                    SlobodnaMjesta = v.SlobodnaMjesta,
                    GradPolaska = v.GradPolaska.Naziv,
                    GradDestinacija = v.GradDestinacija.Naziv,
                    usputni = _db.UsputniGradovi.Where(u => u.VoznjaID == v.VoznjaID).Select(u => new SveVoznjeVM.Usputni
                    {
                        UsputniGradId = u.UsputniGradoviID,
                        Cijena = u.CijenaUsputni,
                        Naziv = u.Grad.Naziv
                    }).ToList(),
                    VoznjaID = v.VoznjaID,
                    KorisnickoIme = v.Vozac.Korisnik.Ime + " " + v.Vozac.Korisnik.Prezime
                }).ToList();

            return View(model);
        }
 

    public IActionResult MojeVoznje(int vozacID)
    {
            SveVoznjeVM model = new SveVoznjeVM();

            model.CurrentUser = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            model.voznje = _db.Voznje
                .Where(a => a.VozacID==vozacID)
                .OrderByDescending(v => v.DatumObjave).Select(v => new SveVoznjeVM.Row
                {
                    AutoNazivModel = v.Automobil.Naziv + " " + v.Automobil.Model,
                    SlikaPath = v.Automobil.SlikaPath,
                    DatumPolaska = v.DatumPolaska,
                    VrijemePolaska = v.VrijemePolaska,
                    PunaCijena = v.PunaCijena,
                    SlobodnaMjesta = v.SlobodnaMjesta,
                    GradPolaska = v.GradPolaska.Naziv,
                    GradDestinacija = v.GradDestinacija.Naziv,
                    KorisnikID = v.VozacID,

                    usputni = _db.UsputniGradovi.Where(u => u.VoznjaID == v.VoznjaID).Select(u => new SveVoznjeVM.Usputni
                    {
                        UsputniGradId = u.UsputniGradoviID,
                        Cijena = u.CijenaUsputni,
                        Naziv = u.Grad.Naziv
                    }).ToList(),

                    VoznjaID = v.VoznjaID,
                    KorisnickoIme = v.Vozac.Korisnik.Ime + " " + v.Vozac.Korisnik.Prezime
                }).ToList();

            return View(model);
    }

    public IActionResult CijenaVoznje(int voznjaID)
    {
        CijenaVoznjeVM model = new CijenaVoznjeVM();

        model = _db.Voznje.Where(v => v.VoznjaID == voznjaID).Select(v => new CijenaVoznjeVM
        {
            GradDestinacija = v.GradDestinacija.Naziv,
            GradPolazak = v.GradPolaska.Naziv
        }).FirstOrDefault();

        model.rows = new List<CijenaVoznjeVM.Row>();
        model.rows = _db.UsputniGradovi.Where(u => u.VoznjaID == voznjaID).Select(u => new CijenaVoznjeVM.Row
        {
            UsputniGradID = u.UsputniGradoviID,
            UsputniNaziv = u.Grad.Naziv,
            UsputniCijena = u.CijenaUsputni
        }).ToList();

        model.VoznjaID = voznjaID;

        return View(model);
    }

    [HttpPost]
    public IActionResult CijenaVoznje(CijenaVoznjeVM mod)
    {
        for (int i = 0; i < mod.rows.Count; i++)
        {
            UsputniGradovi usputni = _db.UsputniGradovi.Find(mod.rows[i].UsputniGradID);

            usputni.CijenaUsputni = mod.rows[i].UsputniCijena;
            _db.UsputniGradovi.Update(usputni);
        }

        _db.SaveChanges();

        return RedirectToAction(nameof(SveVoznje));
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
            DatumObjave = DateTime.Now,
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

        if (mod.SelektiraniGradovi != null)
        {
            return RedirectToAction("CijenaVoznje", "Voznje", new { voznjaID = voznja.VoznjaID });
        }
        else
        {
            return RedirectToAction(nameof(SveVoznje));
        }

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


        return RedirectToAction("CijenaVoznje", "Voznje", new { voznjaID = mod.VoznjaID });
    }
}
}