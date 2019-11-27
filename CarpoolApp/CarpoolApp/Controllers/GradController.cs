using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using CarpoolApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarpoolApp.Controllers
{

    public class GradController : Controller
    {
        private readonly CarpoolAppContext _db;

        public GradController(CarpoolAppContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Grad> Gradovi = _db.Gradovi
                .Include(x=>x.Drzava)
                .ToList();
            ViewData["gradovi"] = Gradovi;
            return View();
        }
        public IActionResult Delete(int id)
        {
            Grad grad = _db.Gradovi.Where(x => x.GradID == id).FirstOrDefault();
            _db.Gradovi.Remove(grad);
            _db.SaveChanges();

            return RedirectToActionPermanent(nameof(Index));
        }

        public IActionResult Create()
        {
            GradVM gradVM = new GradVM();
            gradVM.Drzave = new List<SelectListItem>();
            gradVM.Drzave = _db.Drzave.Select(x => new SelectListItem()
            {
                Text = x.Naziv,
                Value = x.DrzavaID.ToString()
            }).ToList();
            gradVM.Drzave.Insert(0, new SelectListItem()
            {
                Text="Drzava",
                Value="-1", Disabled=true
            });

            return View(gradVM);
        }

        [HttpPost]
        public IActionResult Create(GradVM model)
        {
            _db.Gradovi.Add(new Grad()
            {
                Naziv = model.Naziv,
                PostanskiBroj = model.PostanskiBroj,
                DrzavaID=model.DrzavaID
            });
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}