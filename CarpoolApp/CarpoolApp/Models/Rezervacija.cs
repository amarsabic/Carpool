using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Rezervacija
    {
        public int RezervacijaID { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public int VoznjaID { get; set; }
        public Voznja Voznja { get; set; }
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int? UsputniGradId { get; set; }
        public UsputniGradovi UsputniGrad { get; set; }
        public string OpisPrtljaga { get; set; }
        public bool IsAktivna { get; set; }
    }
}
