using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    
    public class UpdateSerial
    {
        
        public int Id { get; set; }
        public string Modo { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")] //Format as ShortDateTime
        public DateTime Fechaexp { get; set; }
        public int Dispositivos { get; set; }
        public string Serial { get; set; }

    }
}
