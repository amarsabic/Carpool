using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarpoolApp.Areas.Driver.ViewModels.Obavijesti
{
    public class ObavijestDodajVM
    {
        public string Naslov { get; set; }
        public int TipObavijesti { get; set; }
        public List<SelectListItem> tipovi { get; set; }
        public string KratkiOpis { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }
    }
}
