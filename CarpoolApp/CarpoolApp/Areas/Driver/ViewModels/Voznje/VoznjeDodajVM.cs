using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Voznje
{
    public class VoznjeDodajVM
    {
        public int VoznjaID { get; set; }
        public int VozacID { get; set; }
        public int GradPolaskaID { get; set; }
        public List<SelectListItem> GradPolaska { get; set; }

        public int GradDestinacijaID { get; set; }
        public List<SelectListItem> GradDestinacija { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumPolaska { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        public DateTime VrijemePolaska { get; set; }
        public int SlobodnaMjesta { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:#,##0.00#}", ApplyFormatInEditMode = true)]
        public decimal PunaCijena { get; set; }
        public int AutomobilID { get; set; }
        public List<SelectListItem> Automobili { get; set; }

        public List<int> SelektiraniGradovi { get; set; }
        public IEnumerable<SelectListItem> UsputniGradovi { get; set; }

    }
}
