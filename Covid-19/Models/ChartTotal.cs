using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class ChartTotal
    {
        public List<float> Confirmed { get; set; }
        public List<float> Deaths { get; set; }
        public List<float> Recovered { get; set; }
        public List<DateTime> Dates { get; set; }
    }
}
