

using Restaurant.Domain.Core;

namespace Restaurant.Domain.Entities
{
    public class Cliente: Person
    {
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        // Propiedad de navegación
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
