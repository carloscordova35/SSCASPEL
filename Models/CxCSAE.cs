using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    public class CxCSAE
    {
        [Key]
        public string Codigo { get; set; }
        public int Aldia { get; set; }
        public DateTime Fechamasvenc { get; set; }
        public DateTime Ultimomov { get; set; }
        public string Referencia { get; set; }
        public int Numcpto { get; set; }
        public int Nocargo { get; set; }
        public string Factura { get; set; }
        public string Documento { get; set; }
        public double Cargo { get; set; }
        public double Abono { get; set; }
        public DateTime Fecha_apli { get; set; }
        public DateTime Fecha_venc { get; set; }
        public DateTime Fechaelab { get; set; }
        
    }
    }
