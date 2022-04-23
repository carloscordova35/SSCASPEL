using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class CxcDet
    {
        public string cve_clie { get; set; }
        public string descr { get; set; }
        public string refer { get; set; }
        public int num_cargo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_apli { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha_venc { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double saldo { get; set; }

    }
}
