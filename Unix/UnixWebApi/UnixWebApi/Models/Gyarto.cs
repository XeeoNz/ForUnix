using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnixWebApi.Models
{
    public class Gyarto
    {
        public int Id { get; set; }
        public string GyartoNev { get; set; }
        public ICollection<Modell> Modellek { get; set; }
    }
}
