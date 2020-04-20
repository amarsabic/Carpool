using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Voznje
{
    public class CijenaVoznjeVM
    {
        public int VoznjaID { get; set; }
        public string GradPolazak { get; set; }
        public string GradDestinacija { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int UsputniGradID { get; set; }
            public string UsputniNaziv { get; set; }
            public double UsputniCijena { get; set; }
        }
    }
}
