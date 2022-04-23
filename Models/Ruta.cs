using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("ruta")]

    public class Ruta
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }

    }
}
