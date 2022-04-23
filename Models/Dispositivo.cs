using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("dispositivo")]
    public class Dispositivo
    {
        [Key]
        public int ID { get; set; }
        public string Device { get; set; }
    }
}
