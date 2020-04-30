using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class RezervacijeController : BaseController
    {
        public RezervacijeController(CarpoolAppContext db) : base(db)
        {
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}