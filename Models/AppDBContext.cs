using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSCASPEL.Models;

namespace SSCASPEL.Models
{
    public partial class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Precio> Precio { get; set; }
        public virtual DbSet<Impuesto> Impuesto { get; set; }
        public virtual DbSet<Sustitutiva> Sustitutiva { get; set; }
        public virtual DbSet<Acumulativa> Acumulativa { get; set; }
        public virtual DbSet<UnidadesMedida> UnidadesMedida { get; set; }
        public virtual DbSet<Condicion> Condicion { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }
        public virtual DbSet<UpdateSerial> UpdateSerial { get; set; }
        public virtual DbSet<Docto> Documento { get; set; }
        public virtual DbSet<DoctoDet> DocumentoDet { get; set; }
        public virtual DbSet<Cobro> Cobro { get; set; }
        public virtual DbSet<CobroDet> CobroDet { get; set; }
        public virtual DbSet<UMed> UnidadMedida { get; set; }
        public virtual DbSet<InvePresentacion> Presentaciones { get; set; }
        public virtual DbSet<ImageModel> Images { get; set; }
        public virtual DbSet<DatoFEL> DatoFel { get; set; }

        public virtual DbSet<Pedido> Pedido { get; set; }

        public virtual DbSet<Series> Serie { get; set; }

        public virtual DbSet<Banco> Banco { get; set; }

        public virtual DbSet<CxcDet> CXCdet { get; set; }

        public virtual DbSet<MovsDet> MovsDet { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
               // optionsBuilder.UseSqlServer("Data Source=CARLOS-PC;Initial Catalog=SSCASPEL;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // aca va lo que pegue en notepad++
            modelBuilder.Entity<UnidadesMedida>().HasNoKey();
            OnModelCreatingPartial(modelBuilder);

            //OTRO VALOR
            modelBuilder.Entity<ExistProd>(e =>
            {
                e.HasNoKey();
            });

            modelBuilder.Entity<CxcDet>().HasNoKey();
            modelBuilder.Entity<MovsDet>().HasNoKey();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<SSCASPEL.Models.Recibo> Recibo { get; set; }

       
    }
}
