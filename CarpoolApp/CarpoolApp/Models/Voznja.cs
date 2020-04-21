using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Voznja
    {
        public int VoznjaID { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime VrijemePolaska { get; set; }
        public int SlobodnaMjesta { get; set; }
        public decimal PunaCijena { get; set; }

        public int VozacID { get; set; }
        public Vozac Vozac { get; set; }

        public int AutomobilID { get; set; }
        public Automobil Automobil { get; set; }

        public int GradPolaskaID { get; set; }
        public Grad GradPolaska { get; set; }
        public int GradDestinacijaID { get; set; }
        public Grad GradDestinacija { get; set; }

        public List<UsputniGradovi> UsputniGradovi { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public List<Ocjene> Ocjene { get; set; }
    }
}
