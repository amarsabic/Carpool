using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Obavijesti;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class ObavijestiController : BaseController
    {
        public ObavijestiController(CarpoolAppContext db) : base(db)
        {
        }
        public IActionResult Detalji()
        {
            return View();
        }

        public async Task<IActionResult> SveObavijesti(ObavijestiDetaljiVM model)
        {
            ObavijestiDetaljiVM lista = new ObavijestiDetaljiVM();


            var obavijesti = _db.Obavijesti
                .OrderByDescending(x => x.DatumVrijemeObjave)
                 .Select(x => new ObavijestiDetaljiVM.Row()
                 {
                     Naslov = x.Naslov,
                     KratkiOpis = x.KratkiOpis,
                     DatumVrijemeObjave = x.DatumVrijemeObjave,
                     ObavijestiID = x.ObavijestiID,
                     TipObavijestiID = x.TipObavijestiID,
                     TipObavijesti = x.TipObavijesti,
                     KorisnickoIme = x.Vozac.Korisnik.Ime + " " + x.Vozac.Korisnik.Prezime
                 });

            lista.Obavijesti = await PagingList.CreateAsync((IOrderedQueryable<ObavijestiDetaljiVM.Row>)obavijesti, 3, model.Page);
            return PartialView(lista);
        }

        public async Task<IActionResult> LicneObavijesti(ObavijestiDetaljiVM model)
        {
            ObavijestiDetaljiVM lista = new ObavijestiDetaljiVM();

            int vozac = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var obavijesti = _db.Obavijesti.Where(o => o.VozacID == vozac)
                 .OrderByDescending(x => x.DatumVrijemeObjave)
                 .Select(x => new ObavijestiDetaljiVM.Row()
                 {
                     Naslov = x.Naslov,
                     KratkiOpis = x.KratkiOpis,
                     DatumVrijemeObjave = x.DatumVrijemeObjave,
                     ObavijestiID = x.ObavijestiID,
                     TipObavijestiID = x.TipObavijestiID,
                     TipObavijesti = x.TipObavijesti,
                     KorisnickoIme = x.Vozac.Korisnik.Ime + " " + x.Vozac.Korisnik.Prezime
                 });

            lista.Obavijesti = await PagingList.CreateAsync((IOrderedQueryable<ObavijestiDetaljiVM.Row>)obavijesti, 3, model.Page);
            return PartialView(lista);
        }

        public IActionResult Obrisi(int obavijestiId)
        {
            Obavijesti obavijest = _db.Obavijesti.Find(obavijestiId);
            _db.Obavijesti.Remove(obavijest);

            _db.SaveChanges();

            return RedirectToAction(nameof(Detalji));
        }
        public IActionResult Dodaj()
        {
            ObavijestDodajVM Model = new ObavijestDodajVM();
            Model.tipovi = new List<SelectListItem>();
            Model.tipovi = _db.TipObavijesti.Select(t => new SelectListItem()
            {
                Value = t.TipObavijestiID.ToString(),
                Text = t.NazivTipa
            }).ToList();

            return View(Model);
        }

        [HttpPost]
        public IActionResult Dodaj(ObavijestDodajVM Model)
        {
            _db.Obavijesti.Add(new Obavijesti
            {
                VozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                Naslov = Model.Naslov,
                DatumVrijemeObjave = DateTime.Now,
                KratkiOpis = Model.KratkiOpis,
                TipObavijestiID = Model.TipObavijesti
            });

            _db.SaveChanges();

            return RedirectToActionPermanent(nameof(Detalji));
        }

        public IActionResult Uredi(int obavijestiId)
        {
            Obavijesti o = _db.Obavijesti.Find(obavijestiId);
            var model = new ObavijestiUrediVM
            {
                DatumVrijemeObjave = o.DatumVrijemeObjave,
                KratkiOpis = o.KratkiOpis,
                TipObavijesti = o.TipObavijestiID,
                ObavijestId = obavijestiId,
                Naslov = o.Naslov,

                tipovi = _db.TipObavijesti.Select(t => new SelectListItem()
                {
                    Value = t.TipObavijestiID.ToString(),
                    Text = t.NazivTipa
                }).ToList()
            };

            return View("Uredi", model);
        }

        [HttpPost]
        public IActionResult Uredi(ObavijestiUrediVM mod)
        {

            Obavijesti obavijesti = _db.Obavijesti.Find(mod.ObavijestId);

            obavijesti.Naslov = mod.Naslov;
            obavijesti.KratkiOpis = mod.KratkiOpis;
            obavijesti.TipObavijestiID = mod.TipObavijesti;

            _db.Obavijesti.Update(obavijesti);
            _db.SaveChanges();

            return RedirectToAction(nameof(Detalji));
        }
    }
}