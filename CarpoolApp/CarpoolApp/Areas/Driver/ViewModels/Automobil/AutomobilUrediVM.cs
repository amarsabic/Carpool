using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.Areas.Driver.ViewModels.Automobil
{
    public class AutomobilUrediVM : AutomobilDodajVM
    {
        public int AutomobilId { get; set; }
        public string PostojecaSlikaPath { get; set; }
    }
}
