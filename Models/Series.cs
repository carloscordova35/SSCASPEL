using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("serie")]
    public class Series
    {
        [Key]
        public int Id { get; set; }
        public string Serie { get; set; }
        [Display(Name = "Tipo Docto")]
        public string Tipodoc { get; set; }
        [Display(Name = "Con CAI")]
        public bool Concai { get; set; }
        [Display(Name = "C.A.I")]
        public string Cai { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha limite")]
        public DateTime? Fechalim { get; set; }
        [Display(Name = "Folio Inicial")]
        public string Folioi { get; set; }
        [Display(Name = "Folio Final")]
        public string Foliof { get; set; } 
    }
}
