using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using CarpoolApp.Areas.Driver.ViewModels.Rezervacije;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

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

            model.VozacID = vozacID;

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
                    ImePutnika = r.Korisnik.Email.Substring(0, r.Korisnik.Email.IndexOf("@")),
                    OpisPrtljaga = r.OpisPrtljaga
                }).ToList()
            }).ToList();


            return View(model);
        }

        public IActionResult HistorijaVoznji()
        {
            var model = new RezervacijeDetaljiVM();

            var vozacID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            model.VozacID = vozacID;

            model.voznje = _db.Voznje.Where(v => v.VozacID == vozacID && !v.IsAktivna).Select(v => new RezervacijeDetaljiVM.Row2
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
                    ImePutnika = r.Korisnik.Email.Substring(0, r.Korisnik.Email.IndexOf("@")),
                    OpisPrtljaga = r.OpisPrtljaga
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
                IsAktivna = true
            };

            _db.Rezervacije.Add(rez);

            Voznja v = _db.Voznje.Where(x => x.VoznjaID == mod.VoznjaID).FirstOrDefault();
            v.SlobodnaMjesta--;

            _db.SaveChanges();


            var emailTO = _db.Voznje.Where(v => v.VoznjaID == mod.VoznjaID).Select(v => v.Vozac.Korisnik.Email).FirstOrDefault();
            var username = _db.Korisnici.Where(v => v.Id == mod.KorisnikID).Select(v => v.Email.Substring(0, v.Email.IndexOf("@"))).FirstOrDefault();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("CarpoolApp", "carpoolapp2020@gmail.com"));
            message.To.Add(new MailboxAddress(username, emailTO));
            message.Subject = "Rezervacija od korisnika" + " " + username;

            message.Body = new TextPart("plain")
            {
                Text = "Upravo ste dobili novu rezervaciju od korisnika" + " " + username
            };

            using (var client=new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("carpool.rs1@gmail.com", "Carpoolapp2020");
                client.Send(message);
                client.Disconnect(true);
            }

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
            IsAktivna = true
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

        model.putovanja = _db.Rezervacije.
            Where(r => r.KorisnikID == vozacID)
            .OrderByDescending(r => r.DatumRezervacije)
           .Select(r => new ViewModels.Rezervacije.MojaPutovanjaVM.Row
           {
               RezervacijaID = r.RezervacijaID,
               Cijena = r.Voznja.PunaCijena,
               UsputniCijena = r.UsputniGrad.CijenaUsputni,
               DatumVoznje = r.Voznja.DatumPolaska,
               GradDestinacija = r.Voznja.GradDestinacija.Naziv,
               GradPolaska = r.Voznja.GradPolaska.Naziv,
               NazivUsputnog = r.UsputniGrad.Grad.Naziv,
               DatumRezervacije = r.DatumRezervacije,
               IsAktivna = r.IsAktivna,
                   /*ImeVozaca=r.Voznja.Vozac.Korisnik.Ime + " " + r.Voznja.Vozac.Korisnik.Prezime*/
               ImeVozaca = r.Voznja.Vozac.Korisnik.Email.Substring(0, r.Voznja.Vozac.Korisnik.Email.IndexOf("@")),
           }).ToList();


        return View(model);
    }


}
}