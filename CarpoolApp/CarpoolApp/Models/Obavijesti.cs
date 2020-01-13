using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Obavijesti
    {
        public int ObavijestiID { get; set; }
        public string KratkiOpis { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumVrijemeObjave { get; set; }

        public int TipObavijestiID { get; set; }
        public TipObavijesti TipObavijesti { get; set; }

        public bool Vaznost { get; set; }

        public int VozacID { get; set; }
        public Vozac Vozac { get; set; }
    }
}
