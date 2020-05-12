using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Rezervacije
{
    public class RezervacijeDetaljiVM
    {
        public int VozacID { get; set; }
        public List<Row2> voznje { get; set; }
        public class Row2
        {
            public int VoznjaID { get; set; }
            [DataType(DataType.Date)]
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
            public string OpisPrtljaga { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumRezervacije { get; set; }
            public decimal UsputniCijena { get; set; }
            public decimal PunaCijena { get; set; }
        }
    }
}
