using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Rezervacije
{
    public class MojaPutovanjaVM
    {
        public List<Row> putovanja { get; set; }
        public class Row
        {
            public int RezervacijaID { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumVoznje { get; set; }
            [DataType(DataType.Date)]
            public DateTime DatumRezervacije { get; set; }

            public string ImeVozaca { get; set; }
            public string GradPolaska { get; set; }
            public string GradDestinacija { get; set; }
            public string? NazivUsputnog { get; set; }
            public decimal? UsputniCijena { get; set; }
            public decimal Cijena { get; set; }
            public bool IsAktivna { get; set; }
        }
    }
}
