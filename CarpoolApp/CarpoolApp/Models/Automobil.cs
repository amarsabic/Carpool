using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Models
{
    public class Automobil
    {
        public int AutomobilID { get; set; }
        public int VozacID { get; set; }
        public Vozac Vozac { get; set; }
        public string Naziv { get; set; }
        public string Model { get; set; }
        public string Godiste { get; set; }
        public string BrojRegOznaka { get; set; }
        public DateTime DatumIstekaRegistracije { get; set; }
        public string SlikaPath { get; set; }
        public bool IsAktivan { get; set; }
        public List<Voznja> Voznje { get; set; }
    }
}
