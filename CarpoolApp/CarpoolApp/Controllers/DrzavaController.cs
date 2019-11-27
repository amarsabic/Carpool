using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using CarpoolApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Controllers
{
    public class DrzavaController : Controller
    {
        private readonly CarpoolAppContext _db;

        public DrzavaController(CarpoolAppContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Drzava> Drzave = _db.Drzave.ToList();
            ViewData["drzave"] = Drzave;
            return View();
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(DrzavaVM model)
        {
            _db.Drzave.Add(new Drzava()
            {
               Naziv=model.Naziv,
               Skracenica=model.Skracenica
            });
            _db.SaveChanges();

            return View();
        }
        public IActionResult Delete(int id)
        {
            Drzava drzava = _db.Drzave.Where(x => x.DrzavaID == id).FirstOrDefault();
            _db.Drzave.Remove(drzava);
            _db.SaveChanges();

            return RedirectToActionPermanent(nameof(Index));
        }
    }
}