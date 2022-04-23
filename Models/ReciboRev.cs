using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class ReciboRev
    {

        public Cobro Encabezado { get; set; }
        public List<CobroDet> Detalle { get; set; }

        public ReciboRev() {
            Detalle = new List<CobroDet>();
        }

    }
}
