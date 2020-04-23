using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using CarpoolApp.ViewModels;

namespace CarpoolApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CarpoolAppContext _db;

        public HomeController(ILogger<HomeController> logger, CarpoolAppContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            SearchDestinacije mod = new SearchDestinacije();

            mod.polazista = _db.Gradovi.Select(p => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = p.GradID.ToString(),
                Text = p.Naziv
            }).ToList();
            mod.odredista = _db.Gradovi.Select(p => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = p.GradID.ToString(),
                Text = p.Naziv
            }).ToList();

            return View(mod);
        }

        public IActionResult SearchDestinacija(SearchDestinacije mod)
        {
            return RedirectToActionPermanent("SearchVoznje", "Voznje", new { Area = "Driver", polazisteId = mod.SearchPolazisteId, odredisteId = mod.SearchOdredisteId });

            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
