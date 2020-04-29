using CarpoolApp.Models;
using CarpoolApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewComponents
{
    public class NajpoznatijeVoznje: ViewComponent
    {
        private readonly CarpoolAppContext _db;

        public NajpoznatijeVoznje(CarpoolAppContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            NajpoznatijeVoznjeVM model = new NajpoznatijeVoznjeVM();

            model.voznje = _db.Voznje
                
                .OrderByDescending(v => v.DatumObjave).Select(v => new NajpoznatijeVoznjeVM.Row
            {
                GradDestinacijaId=v.GradDestinacijaID,
                GradDestinacija=v.GradDestinacija.Naziv,
                GradPolaskaId=v.GradPolaskaID,
                GradPolaska=v.GradPolaska.Naziv
            }).Take(3).ToList();

            return View("NajpoznatijeVoznje", model);
        }

    }
}
