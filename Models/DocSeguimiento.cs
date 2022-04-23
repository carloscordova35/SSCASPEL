using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class DocSeguimiento
    {      
        public string tdoc { get; set; }
        [Key]
        public string cve_doc { get; set; }
        public DateTime fecha { get; set; }
        public string tdocs { get;set; }
        public string docsig { get; set; }
        public string estado { get; set; }
    }
}
