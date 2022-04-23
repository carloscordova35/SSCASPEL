using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    
    [Table("impuesto")]
    public class Impuesto
    {
        [Key]
        public int Id { get; set; }
        public int Esquema { get; set; }
        public string Nombre { get; set; }
        public double Impu1 { get; set; }
        public double Impu2 { get; set; }
        public double Impu3 { get; set; }
        public double Impu4 { get; set; }

    }
}
