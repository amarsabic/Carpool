using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.ViewModels
{
    public class SearchDestinacije
    {
        public int SearchPolazisteId { get; set; }
        public List<SelectListItem> polazista { get; set; }
        public int SearchOdredisteId { get; set; }
        public List<SelectListItem> odredista { get; set; }
    }
}
