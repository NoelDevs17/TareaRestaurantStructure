

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;

namespace Restaurant.Infraestructure.EntitiesConfiguration
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.IdPlato);

            builder.HasMany(m => m.DetallePedidos)
                   .WithOne(d => d.Menu)
                   .HasForeignKey(d => d.IdPlato);
        }
    }
}
