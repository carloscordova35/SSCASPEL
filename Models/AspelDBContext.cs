using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SSCASPEL.Models
{
    public partial class AspelDBContext : DbContext
    {
        public AspelDBContext()
        {
        }

        public AspelDBContext(DbContextOptions<AspelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Vendedor> Vendedor { get; set; }
        public virtual DbSet<DocSeguimiento> DocSeguimientos { get; set; }
        public virtual DbSet<FactPend> FactPendientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //  optionsBuilder.UseSqlServer("Data Source=CARLOS-PC;Initial Catalog=SAE_EMPRESA01;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
