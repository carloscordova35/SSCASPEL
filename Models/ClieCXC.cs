using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class ClieCXC
    {
        public string imagepath { get; set; }
        public string fechac { get; set; }
        public Parametros Param { get; set; }
        public Cliente cliente;
        public List<CxcDet> detalle;

        public ClieCXC() {
            detalle = new List<CxcDet>();
        }
    }
}
