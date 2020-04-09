using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19.Models
{
    public class RecoveredTable
    {
        [Key]
        public int id { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public float Recovered { get; set; }
    }
}
