using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class DashboardModel
    {
        public List<string> info { get; set; }
        public List<map> mapData { get; set; }
        public List<ChartTotal> chartTotal { get; set; }
    }
}
