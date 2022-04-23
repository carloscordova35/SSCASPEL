using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public partial class UnidadesMedida
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int Nivel { get; set; }
        public string Unmed { get; set; }
        [Column("univenta")]
        public double Unidades { get; set; }
    }
}
