﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CarpoolApp.Models
{
    public class Korisnik : IdentityUser<int>
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }


    }
}