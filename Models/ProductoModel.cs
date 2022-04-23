using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class ProductoModel
    {

        public Producto prod { get; set; }
        public List<ImageModel> imgn { get; set; }
        public List<UnidadesMedida> unmd { get; set; }
        public Usuario user { get; set; }
    }
}
