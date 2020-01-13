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
        public int UsputniGradODID { get; set; }
        public UsputniGradovi UsputniGradoviOD { get; set; }
        public int UsputniGradDOID { get; set; }
        public UsputniGradovi UsputniGradoviDO { get; set; }
        public int PrtljagID { get; set; }
        public Prtljag Prtljag { get; set; }
    }
}
