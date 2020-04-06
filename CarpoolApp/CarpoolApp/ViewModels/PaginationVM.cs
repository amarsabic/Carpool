using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarpoolApp.ViewModels
{
    public class PaginationVM
    {
        public int Page { get; set; }

        public int PageIndex { get; set; }
        public int PageCount { get; set; }
        public int StartPageIndex { get; set; }
        public int StopPageIndex { get; set; }
        public int NextPage { get; set; }
        public int PreviousPage { get; set; }
    }
}
