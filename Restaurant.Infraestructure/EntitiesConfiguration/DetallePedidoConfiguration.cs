
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infraestructure.EntitiesConfiguration
{
    public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
    {
        public void Configure(EntityTypeBuilder<DetallePedido> builder)
        {

            builder.ToTable("DetallePedido");
            builder.HasKey(d => d.IdDetallePedido);

            builder.Property(d => d.Subtotal)
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(d => d.Pedido)
                   .WithMany(p => p.DetallesPedido)
                   .HasForeignKey(d => d.IdPedido);

            builder.HasOne(d => d.Menu)
                   .WithMany(m => m.DetallePedidos)
                   .HasForeignKey(d => d.IdPlato);
        }
    }
}
