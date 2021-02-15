using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnixWebApi.Models
{
    public class Auto
    {
        public string GyartoNev { get; set; }
        public string ModellNev { get; set; }
        public int GyartoId { get; set; }
        public int ModellId { get; set; }
        public int ReszletekId { get; set; }
        public int Ajtok { get; set; }
        public int Teljesitmeny { get; set; }
        public int Ulesek { get; set; }
        public int Evjarat { get; set; }
    }
}
