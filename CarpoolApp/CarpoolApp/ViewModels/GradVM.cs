using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Web.ViewModels
{
    public class GradVM
    {
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public int DrzavaID { get; set; }

       public List<SelectListItem> Drzave { get; set; }
    }
}
