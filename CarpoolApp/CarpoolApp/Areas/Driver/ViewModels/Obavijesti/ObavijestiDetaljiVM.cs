using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarpoolApp.Models;

namespace CarpoolApp.Areas.Driver.ViewModels.Obavijesti
{
    public class ObavijestiDetaljiVM
    {
        public List<Row> obavijesti { get; set; }
        public class Row
        {
            public int ObavijestiID { get; set; }
            public string KratkiOpis { get; set; }
            public string Naslov { get; set; }
            public DateTime DatumVrijemeObjave { get; set; }

            public int TipObavijestiID { get; set; }
            public TipObavijesti TipObavijesti { get; set; }
            public string KorisnickoIme { get; set; }
        }
    }
}
