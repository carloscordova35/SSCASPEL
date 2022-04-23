using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("precio")]
    public partial class Precio
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Lista { get; set; }
        public string Nomlista { get; set; }
        [Column("precio")]
        public double Preciou { get; set; }
    }
}
