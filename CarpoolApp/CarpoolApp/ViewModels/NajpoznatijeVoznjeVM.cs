using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.ViewModels
{
    public class NajpoznatijeVoznjeVM
    {
        public List<Row> voznje { get; set; }
        public class Row
        {
            public int GradPolaskaId { get; set; }
            public string GradPolaska { get; set; }
            public int GradDestinacijaId { get; set; }
            public string GradDestinacija { get; set; }
        }
    }
}
