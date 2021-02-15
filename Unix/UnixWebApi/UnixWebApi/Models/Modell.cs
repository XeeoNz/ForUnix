using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnixWebApi.Models
{
    public class Modell
    {
        public int Id { get; set; }
        public string ModellNev { get; set; }
        public int GyartoId { get; set; }
        public Gyarto Gyarto { get; set; }
        public int ReszletekId { get; set; }
        public Reszletek Reszletek { get; set; }
    }
}
