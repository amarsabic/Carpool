using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Rezervacije
{
    public class PunaRezervacijaVM
    {
        public int VoznjaID { get; set; }
        public string GradPolaska { get; set; }
        public string GradDestinacija { get; set; }
        public decimal PunaCijena { get; set; }
        public int KorisnikID { get; set; }
        public string OpisPrtljag { get; set; }
    }
}
