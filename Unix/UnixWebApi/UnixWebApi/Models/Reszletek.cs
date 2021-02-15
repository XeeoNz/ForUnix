using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnixWebApi.Models
{
    public class Reszletek
    {
        public int Id { get; set; }
        public int Ajtok { get; set; }
        public int Teljesitmeny { get; set; }
        public int Ulesek { get; set; }
        public int Evjarat { get; set; }
        public Modell Modell { get; set; }
    }
}
