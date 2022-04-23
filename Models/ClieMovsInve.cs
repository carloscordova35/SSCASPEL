using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class ClieMovsInve
    {
        public string imagepath { get; set; }
        public string fechac { get; set; }
        public string fechai { get; set; }
        public Parametros Param { get; set; }
        public Cliente cliente;
        public List<MovsDet> detalle;

        public ClieMovsInve()
        {
            detalle = new List<MovsDet>();
        }
    }
}
