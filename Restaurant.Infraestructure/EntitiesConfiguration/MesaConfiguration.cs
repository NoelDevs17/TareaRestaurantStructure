

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities;

namespace Restaurant.Infraestructure.EntitiesConfiguration
{
    public class MesaConfiguration : IEntityTypeConfiguration<Mesa>
    {
        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            builder.ToTable("Mesa");
            builder.HasKey(m => m.IdMesa);

            builder.HasMany(m => m.Pedidos)
                   .WithOne(p => p.Mesa)
                   .HasForeignKey(p => p.IdMesa);
        }
    }
}
