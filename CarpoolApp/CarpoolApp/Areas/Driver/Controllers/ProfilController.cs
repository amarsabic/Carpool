using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    public class ProfilController : BaseController
    {
        public ProfilController(CarpoolAppContext db) : base(db)
        {
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}