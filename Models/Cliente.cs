using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("cliente")]
    public partial class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Idsae { get; set; }
        public string Estado { get; set; }
        public string Nombre { get; set; }
        [Display(Name = "NIT")]
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Exento { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Saldo { get; set; }
        public double Descuento { get; set; }
        public string Clasificacion { get; set; }
        public string Esprospecto { get; set; }
        public string Clocation { get; set; }
        public string Cvevend { get; set; }
        public string Transportep { get; set; }
        public string Observacion { get; set; }
    }
}
