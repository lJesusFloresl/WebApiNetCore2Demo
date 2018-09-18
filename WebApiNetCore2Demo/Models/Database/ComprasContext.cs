using Microsoft.EntityFrameworkCore;

namespace WebApiNetCore2Demo.Models.Database
{
    public partial class ComprasContext : DbContext
    {
        public ComprasContext()
        {
        }

        public ComprasContext(DbContextOptions<ComprasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<OrdenVenta> OrdenVenta { get; set; }
        public virtual DbSet<OrdenVentaDetalle> OrdenVentaDetalle { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<OrdenVenta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasColumnName("cliente")
                    .HasMaxLength(100);

                entity.Property(e => e.FechaCompra)
                    .HasColumnName("fechaCompra")
                    .HasColumnType("datetime");

                entity.Property(e => e.FormaPagoId).HasColumnName("formaPagoId");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.FormaPago)
                    .WithMany(p => p.OrdenVenta)
                    .HasForeignKey(d => d.FormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenVenta_FormaPago");
            });

            modelBuilder.Entity<OrdenVentaDetalle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.OrdenVentaId).HasColumnName("ordenVentaId");

                entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");

                entity.Property(e => e.ProductoId).HasColumnName("productoId");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.HasOne(d => d.OrdenVenta)
                    .WithMany(p => p.OrdenVentaDetalle)
                    .HasForeignKey(d => d.OrdenVentaId)
                    .HasConstraintName("FK_OrdenVentaDetalle_OrdenVenta");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.OrdenVentaDetalle)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenVentaDetalle_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasMaxLength(10);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(100);

                entity.Property(e => e.PrecioUnitario).HasColumnName("precioUnitario");
            });
        }
    }
}
