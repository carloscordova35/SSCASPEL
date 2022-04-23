using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class RutaDetail
    {
        public Ruta ruta { get; set; }
        public List<Detalle> detalle { get; set; }

        public RutaDetail() {
            detalle = new List<Detalle>();
        }
    }

    
    public class Detalle{
        public int id { get; set; }
        public int idclie { get; set; }
        public string codigosae { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
    }
}
