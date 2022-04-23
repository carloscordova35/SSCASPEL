using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("inventariopres")]
    public partial class InvePresentacion
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Unmed { get; set; }
        public double Univenta { get; set; }

    }
}
