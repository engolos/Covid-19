using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class TweetDataTable
    {
        public int id { get; set; }
        public string username { get; set; }
        public string tweet { get; set; }
        public DateTime date { get; set; }
        public double favorites { get; set; }
        public double retweets { get; set; }
        public string link { get; set; }
    }
}
