using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("datofel")]
    public class DatoFEL
    {
        [Key]
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Fechacreado { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Fechaaut { get; set; }
        public string Tipofel { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Numeroaut { get; set; }
        public int Estado { get; set; }
        public string Moneda { get; set; }
        public string Certificador { get; set; }
        public string Nitcert { get; set; }
    }
}
