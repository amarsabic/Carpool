using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarpoolApp.Areas.User.Controllers
{
    [Area("User")] 
    [Authorize] // ne može pristupiti kontroleru ako nije logiran
    
    public class ProfilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}