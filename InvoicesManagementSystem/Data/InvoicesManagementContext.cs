using InvoicesManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Data
{
    public class InvoicesManagementContext: DbContext
    {
        public InvoicesManagementContext(DbContextOptions<InvoicesManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .HasKey(f => new { f.IdFactura, f.IdLocatie });
            modelBuilder.Entity<Factura>()
                .HasOne(f => f.DetaliiFactura)
                .WithOne(d => d.Factura)
                .HasForeignKey<DetaliiFactura>(d => new { d.IdFactura, d.IdLocatie }); 

            modelBuilder.Entity<DetaliiFactura>()
                .HasKey(f => new { f.IdDetaliiFactura, f.IdLocatie });
        }

        public DbSet<Factura> Facturi { get; set; }
        public DbSet<DetaliiFactura> DetaliiFacturi { get; set; }
        public DbSet<Locatie> Locatii { get; set; }
    }
}
