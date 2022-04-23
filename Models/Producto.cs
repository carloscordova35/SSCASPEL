using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSCASPEL.Models
{
    [Table("inventario", Schema = "dbo")]
    public partial class Producto
    {
        [Key]
        [Required]
        public string Codigo { get; set; }
        public string Barcode { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public int Esquema { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Precio { get; set; }
        [Display(Name = "Email Address")]
        public string Conserie { get; set; }
        public string Tipo { get; set; }
        public double Existencia { get; set; }
        public string Linea { get; set; }
        [Display(Name = "Descripcion Linea")]
        public string Descrlinea { get; set; }
        [Display(Name = "Stock Minimo")]
        public double Sminimo { get; set; }
        public int Almacen { get; set; }

        public string Codigoalt { get; set; }

        public double getPrecio()
        {
            return 1.10;
        }
    }
}
