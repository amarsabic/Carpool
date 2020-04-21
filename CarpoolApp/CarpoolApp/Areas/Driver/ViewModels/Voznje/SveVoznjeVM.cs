using CarpoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Voznje
{
    public class SveVoznjeVM
    {
        public List<Row> voznje { get; set; }

        public SveVoznjeVM()
        {
            voznje = new List<Row>();
        }
        public class Row
        {
            public int VoznjaID { get; set; }
            public string KorisnickoIme { get; set; }
            public DateTime DatumPolaska { get; set; }
            public DateTime VrijemePolaska { get; set; }
            public int SlobodnaMjesta { get; set; }
            public decimal PunaCijena { get; set; }
            public string GradPolaska { get; set; }
            public string GradDestinacija { get; set; }
            public string SlikaPath { get; set; }
            public string AutoNazivModel { get; set; }
            public List<string> UsputniGradovi { get; set; }
        }
    }
}
