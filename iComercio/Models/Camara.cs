using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iComercio.Models
{
    public class Camara
    {
        public IEnumerable<string> Entidades { get; set; }

        public override string ToString()
        {
            return string.Join(String.Empty, Entidades);
        }
    }
}
