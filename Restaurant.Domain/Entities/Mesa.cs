﻿

namespace Restaurant.Domain.Entities
{
    public class Mesa
    {
        public int IdMesa { get; set; }
        public string Capacidad { get; set; }
        public string Estado { get; set; }

        // Propiedad de navegación
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
