using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("banco")]
    public class Banco
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Moneda { get; set; }

    }
}
