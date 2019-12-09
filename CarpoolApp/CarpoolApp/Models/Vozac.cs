using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Vozac
    {
        public int VozacID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }
        public List<Automobil> Automobili { get; set; }
        public string BrVozackeDozvole { get; set; }
        public DateTime DatumIstekaVozackeDozvole { get; set; }
    }
}
