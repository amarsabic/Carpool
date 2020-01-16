using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Automobil
{
    public class AutomobilDodajVM
    {
        public string Naziv { get; set; }
        public string Model { get; set; }
        public string Godiste { get; set; }
        public string BrojRegOznaka { get; set; }
        public DateTime DatumIstekaRegistracije { get; set; }
        public string Slika { get; set; }
    }
}
