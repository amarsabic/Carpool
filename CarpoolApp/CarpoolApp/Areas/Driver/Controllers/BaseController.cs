using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.Driver.Controllers
{
    [Area("Driver")]
    [Authorize] // ne može pristupiti kontroleru ako nije logiran
    public class BaseController : Controller
    {
        public CarpoolAppContext _db;

        public BaseController(CarpoolAppContext db)
        {
            _db = db;
        }
    }
}