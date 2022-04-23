using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("servicio")]
    public class Servicio
    {
        [Key]
        public int id { get; set; }
        public int idclie { get; set; }
        public string cveart { get; set; }
        public string nocontador { get; set; }
        public int noservicio { get; set; }
    }
}
