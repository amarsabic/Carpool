using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Preferencije
    {
        public int PreferencijeID { get; set; }
        public bool Dozvoljeno_pusenje { get; set; }
        public bool Dozvoljene_zivotinje { get; set; }
        
        public int? MuzikaID { get; set; }
        public Muzika Muzika { get; set; }

       
    }
}
