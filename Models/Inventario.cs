using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("INVE01",Schema ="dbo")]
    public partial class Inventario
    {
        [Key]
        public string CVE_ART { get; set; }
        public string DESCR { get; set; }
        public double EXIST { get; set; }
        
    }
}
