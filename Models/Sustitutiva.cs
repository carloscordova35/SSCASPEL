using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("pol1sustitutiva")]
    public class Sustitutiva
    {
        [Key]
        public int Id { get; set; }
        public int Politica { get; set; }
        public string Descripcion { get; set; }
        public string St { get; set; }
        public string Cve_ini { get; set; }
        public string Cve_fin { get; set; }
        public string Lin_prod { get; set; }
        public double Vol_min { get; set; }
        public string Clie_d { get; set; }
        public string Clie_h { get; set; }
        public string Clas_clie { get; set; }
        public string Fechad { get; set; }
        public string Fechah { get; set; }
        public string T_pol { get; set; }
        public string Prc_mon { get; set; }
        public int Lista_prec { get; set; }
        public double Val { get; set; }
        public string Cvezona { get; set; }
    }
}
