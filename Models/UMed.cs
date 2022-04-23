using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("inventariounmed")]
    public partial class UMed
    {
        [Key]
        public int Id { get; set; }
        public string Unmed{get;set;}
        public int Nivel { get; set; }
    }
}
