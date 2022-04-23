using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("recibodet")]
    public class CobroDet
    {
        [Key]
        public int Id { get; set; }
        public int Idr { get; set; }
        public int Partida { get; set; }
        public string Refer { get; set; }
        public DateTime Fecha { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Saldo { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Abono { get; set; }
        public int Mar { get; set; }
        
    }
}
