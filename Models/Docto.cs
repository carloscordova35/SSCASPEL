using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{

    [Table("docto")]
    public partial class Docto
    {
        [Key]
        public int Id { get; set; }
        public string Cvedoc { get; set; }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public int Idclie { get; set; }
        public string Cliente { get; set; }
        public string Nombreclie { get; set; }
        public string Rfc { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fechaen { get; set; }
        public string Vendedor { get; set; }
        public int Esquema { get; set; }
        public string? Supedido { get; set; }
        public string Condicion { get; set; }
        public string Observacion { get; set; }
        public string? Transporte { get; set; }
        public string? Direntrega { get; set; }
        public string Clocation { get; set; }
        public int Estado { get; set; } 
        public DateTime Fechaws { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Canttot { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Impuesto1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Impuesto2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Impuesto3 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Impuesto4 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Descuento { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Total { get; set; }
        public int Iduser { get; set; }
        public int Noalmacen { get; set; }
        public string Uidev { get; set; }
    }
}
