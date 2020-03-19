using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Automobil
{
    public class AutomobilUrediVM
    {
        public int AutomobilId { get; set; }
        public string Naziv { get; set; }
        public string Model { get; set; }
        public string Godiste { get; set; }
        public string BrojRegOznaka { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumIstekaRegistracije { get; set; }
        public IFormFile Slika { get; set; }
        public string SlikaPath { get; set; }
    }
}
