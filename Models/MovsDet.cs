using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class MovsDet
    {
        public string cve_doc { get; set; }
        public int num_alm { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_doc { get; set; }
        public string cve_art { get; set; }
        public string descr { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double cant { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double precio { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double venta { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double impu4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double totimp4 { get; set; }

    }
}
