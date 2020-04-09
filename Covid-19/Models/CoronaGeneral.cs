using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class CoronaGeneral
    {
        public string country { get; set; }
        public string totalCases { get; set; }
        public string newCases { get; set; }
        public string totalDeaths { get; set; }
        public string newDeaths { get; set; }
        public string totalRecovered { get; set; }
        public string activeCases { get; set; }
    }
}
