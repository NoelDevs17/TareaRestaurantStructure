using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;


namespace Restaurant.Infraestructure.EntitiesConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.IdPedido);

            builder.HasOne(p => p.Cliente)
                   .WithMany(c => c.Pedidos)
                   .HasForeignKey(p => p.IdCliente);

            builder.HasOne(p => p.Mesa)
                   .WithMany(m => m.Pedidos)
                   .HasForeignKey(p => p.IdMesa);

            builder.HasMany(p => p.DetallePedidos)
                   .WithOne(d => d.Pedido)
                   .HasForeignKey(d => d.IdPedido);
        }
    }
}
