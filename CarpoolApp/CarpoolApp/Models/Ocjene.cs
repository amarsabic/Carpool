using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Ocjene
    {
        public int OcjeneID { get; set; }
        public string Komentar { get; set; }
        public int TipOcjeneID{ get; set; }
        public TipOcjene TipOcjene { get; set; }
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int VoznjaID { get; set; }
        public Voznja Voznja { get; set; }
    }
}
