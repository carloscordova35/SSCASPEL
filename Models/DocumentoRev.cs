using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class DocumentoRev
    {
        public string imagepath { get; set; }
        public Parametros Param { get; set; }
        public Docto Encabezado { get; set; }
        public List<DoctoDet2> Detalle2 { get; set; }
        public List<DoctoDet> Detalle { get; set; }


        public DocumentoRev()
        {
            Detalle2= new List<DoctoDet2>();
            Detalle = new List<DoctoDet>();
        }
    }
}
