using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("condicion")]
    public partial class Condicion
    {
        [Key]
        public int Id { get; set; }
        [Column("condicion")]
        public string Descripcion { get; set; }
    }
}
