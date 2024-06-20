
using Restaurant.Domain.Core;

namespace Restaurant.Domain.Entities
{
    public class Pedido: AuditableEntity
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal? Total { get; set; }

        public Cliente Cliente { get; set; } // Propiedad de navegacion a Cliente
        public Mesa Mesa { get; set; } // Propiedad de navegacion a Mesa
        public ICollection<DetallePedido> DetallePedidos { get; set; }
        public ICollection<Factura> Facturas { get; set; }

    }
}
