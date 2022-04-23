using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class FactPend
    {
        public string cliente { get; set; }
        [Key]
        public string refer { get; set; }
        public DateTime fechav { get; set; }
        public double saldo { get; set; }
       
       

    }
}
