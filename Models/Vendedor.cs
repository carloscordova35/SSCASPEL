using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("VEND01")]
    public class Vendedor
    {
        [Key]
        [Column("CVE_VEND")]
        public string cve_vend { get; set; }
        [Column("NOMBRE")]
        public string nombre { get; set; }
        [Column("CORREOE")]
        public string correoe { get; set; }
    }
}
