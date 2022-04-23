using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSCASPEL.Models
{
    [Table("usuario")]
    public partial class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("rol")]
        public int? Rol { get; set; }
        [Column("cvevend")]
        [StringLength(5)]
        public string Cvevend { get; set; }
        [Column("habilitado")]
        public int? Habilitado { get; set; }
        [StringLength(5)]
        public string Tipo { get; set; }

        [StringLength(1)]
        public string Docpred { get; set; }

        public int Noalmacen { get; set; }
        [Display(Name = "Serie predeterminada")]
        public string Seriepred { get; set; }
        public string Rutaest { get; set; }

    }
}
