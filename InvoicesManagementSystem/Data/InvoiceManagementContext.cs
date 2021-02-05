using InvoicesManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoicesManagementSystem.Data
{
    public class InvoiceManagementContext : DbContext
    {
        public InvoiceManagementContext(DbContextOptions<InvoiceManagementContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .HasKey(f => new { f.IdFactura, f.IdLocatie });
            modelBuilder.Entity<Factura>()
                .HasMany(f => f.DetaliiFactura)
                .WithOne(d => d.Factura)
                .HasForeignKey(d => new { d.IdFactura, d.IdLocatie });

            modelBuilder.Entity<Factura>()
           .HasOne(f => f.Locatie)
           .WithMany(l => l.Facturi)
           .HasForeignKey(f => f.IdLocatie);

            modelBuilder.Entity<DetaliiFactura>()
                .HasKey(f => new { f.IdDetaliiFactura, f.IdLocatie });

            modelBuilder.Entity<DetaliiFactura>()
           .HasOne(d => d.Locatie)
           .WithMany(l => l.DetaliiFacturi)
           .HasForeignKey(d => d.IdLocatie)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Locatie>().HasData(
                new Locatie()
                {
                    IdLocatie = 1,
                    Nume = "Brasov",
                    Adresa = "Strada Muresenilor"
                },
                new Locatie()
                {
                    IdLocatie = 2,
                    Nume = "Bucuresti",
                    Adresa = "Strada Balcescu"
                }
           );
        }

        public DbSet<Factura> Facturi { get; set; }
        public DbSet<DetaliiFactura> DetaliiFacturi { get; set; }
        public DbSet<Locatie> Locatii { get; set; }
    }
}
