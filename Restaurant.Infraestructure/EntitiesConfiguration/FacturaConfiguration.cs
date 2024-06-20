

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infraestructure.EntitiesConfiguration
{
    public class FacturaConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(f => f.IdFactura);

            builder.HasOne(f => f.Pedido)
                   .WithMany(p => p.Facturas)
                   .HasForeignKey(f => f.IdPedido);
        }
    }
}
