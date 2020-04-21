using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public CijenaVoznjeVM()
        {
            rows = new List<Row>();
        }
        public class Row
        {
            public int UsputniGradID { get; set; }
            public string UsputniNaziv { get; set; }
            [DataType(DataType.Currency)]
            [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
            public decimal UsputniCijena { get; set; }
        }
    }
}
