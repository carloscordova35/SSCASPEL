using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("parametros")]
    public class Parametros
    {
        [Key]
        public int Id { get; set; }
        public int Mostrexist { get; set; }
        public int Cliexvend { get; set; }
        public int Selesq { get; set; }
        public string Modo { get; set; }
        public DateTime Fechaexp { get; set; }
        public int Dispositivos { get; set; }
        public string Serial { get; set; }
        public string Empresa { get; set; }
        public string Direccion { get; set; }
        public string Rfc { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Integraaspel { get; set; }
        public string Cintegradoa { get; set; }
        public string Tipouserfin { get; set; }
        public string Docpred { get; set; }
        public int Intfel { get; set; }
        public string Gface { get; set; }
        public string Userfel { get; set; }
        public string Passfel { get; set; }
        public string Pfxfel { get; set; }

        public string Formato { get; set; }
        public int Cambiarprecio { get; set; }
    }
}
