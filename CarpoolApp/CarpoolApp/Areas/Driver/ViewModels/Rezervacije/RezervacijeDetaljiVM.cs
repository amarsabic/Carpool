using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Rezervacije
{
    public class RezervacijeDetaljiVM
    {
        public List<Row2> voznje { get; set; }
        public class Row2
        {
            public int VoznjaID { get; set; }
            public DateTime DatumVoznje { get; set; }
            public string GradPolaska { get; set; }
            public string GradDestinacija { get; set; }
            public List<Row> rezervacije { get; set; }
        }
        public class Row
        {
            public int RezervacijaID { get; set; }
            public string? NazivUsputnog { get; set; }
            public string ImePutnika { get; set; }
            public DateTime DatumRezervacije { get; set; }
            public decimal UsputniCijena { get; set; }
            public decimal PunaCijena { get; set; }
        }
    }
}
