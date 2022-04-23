using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{


    public partial class DoctoDet2
    {
        [Key]
        public int Id { get; set; }
        public int Iddoc { get; set; }
        public int Partida { get; set; }
        public double Cantidad { get; set; }
        public double Cantxuv { get; set; }
        public string Cveart { get; set; }
        public string Descr { get; set; }
        public double Precio { get; set; }
        public int Apartado { get; set; }
        public string Serie { get; set; }
        public int Esquema { get; set; }
        public int Politica { get; set; }
        public double Impuesto1 { get; set; }
        public double Impuesto2 { get; set; }
        public double Impuesto3 { get; set; }
        public double Impuesto4 { get; set; }
        public double Desc1 { get; set; }
        public double Desc2 { get; set; }
        public double Tipcam { get; set; }
        public int Univen { get; set; }
        public string Tipprod { get; set; }
        public string Lote { get; set; }
        [DisplayFormat(DataFormatString = "{0:N5}")]
        public double Preciou { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Totalpartida { get; set; }
        public string Observacion { get; set; }
        public string Imagename { get; set; }

    }
}
