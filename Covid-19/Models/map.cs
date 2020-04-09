using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class map
    {
        public string countrycode { get; set; }
        public string country { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int confirmed { get; set; }
        public int? deaths { get; set; }
        public int? recovered { get; set; }
        public int? active { get; set; }
    }
}
