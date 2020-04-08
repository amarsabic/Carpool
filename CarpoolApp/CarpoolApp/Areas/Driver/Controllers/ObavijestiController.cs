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

        //public IActionResult LicneObavijesti()
        //{
        //    ObavijestiDetaljiVM lista = new ObavijestiDetaljiVM();
        //    int vozac = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        //    lista.obavijesti = _db.Obavijesti.Where(o => o.VozacID == vozac)
        //        .Select(x => new ObavijestiDetaljiVM.Row()
        //        {
        //            Naslov = x.Naslov,
        //            KratkiOpis = x.KratkiOpis,
        //            DatumVrijemeObjave = x.DatumVrijemeObjave,
        //            ObavijestiID = x.ObavijestiID,
        //            TipObavijestiID = x.TipObavijestiID,
        //            TipObavijesti = x.TipObavijesti,
        //            KorisnickoIme = x.Vozac.Korisnik.Ime + " " + x.Vozac.Korisnik.Prezime
        //        }).ToList();

        //    return PartialView(lista);
        //}

        public async Task<IActionResult> SveObavijesti(ObavijestiDetaljiVM model)
        {
            ObavijestiDetaljiVM lista = new ObavijestiDetaljiVM();
           

            var obavijesti = _db.Obavijesti
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

            lista.Obavijesti = await PagingList.CreateAsync((IOrderedQueryable<ObavijestiDetaljiVM.Row>)obavijesti, 2, model.Page);
            return PartialView(lista);
        }

        public async Task<IActionResult> LicneObavijesti(ObavijestiDetaljiVM model)
        {
            ObavijestiDetaljiVM lista = new ObavijestiDetaljiVM();

            int vozac = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var obavijesti = _db.Obavijesti.Where(o => o.VozacID == vozac)
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

            lista.Obavijesti = await PagingList.CreateAsync((IOrderedQueryable<ObavijestiDetaljiVM.Row>)obavijesti, 4, model.Page);
            return PartialView(lista);
        }

        public IActionResult Obrisi(int obavijestID)
        {
            Obavijesti obavijest = _db.Obavijesti.Find(obavijestID);
            _db.Obavijesti.Remove(obavijest);

            _db.SaveChanges();

            return Redirect("/Driver/Obavijesti/Detalji");
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
    }
}