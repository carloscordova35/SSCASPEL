using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("recibo")]
    public class Cobro
    {
        [Key]
        public int Id { get; set; }
        public int Idclie { get; set; }
        public string Cliente { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public string Forma { get; set; }
        public string Referencia { get; set; }
        public string Forma2 { get; set; }
        public string Referencia2 { get; set; }
        public string Bancocq { get; set; }
        public string Bancoin { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Total { get; set; }
        public DateTime Fechaws { get; set; }
    }
}
