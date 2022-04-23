using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class Recibo
    {

        public int id { get; set; }
        public int idclie { get; set; }
        public string cliente { get; set; }
        public string fecha { get; set; }
        public string forma { get; set; }
        public string referencia { get; set; }
        public string forma2 { get; set; }
        public string referencia2 { get; set; }
        public string bancocq { get; set; }
        public string bancoin { get; set; }
        public double total { get; set; }

        public List<ReciboDet> detalle { get; set; }

        public Recibo(){
            detalle = new List<ReciboDet>();
        }


    }
}
