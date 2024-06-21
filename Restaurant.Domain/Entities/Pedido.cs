
using Restaurant.Domain.Core;

namespace Restaurant.Domain.Entities
{
    public class Pedido: AuditableEntity
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public int IdMesa { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; } // Agregar propiedad de navegación si es necesaria
        public Mesa Mesa { get; set; } // Agregar propiedad de navegación si es necesaria
        public List<DetallePedido> DetallesPedido { get; set; } // Agregar propiedad de navegación si es necesaria
        public ICollection<Factura> Facturas { get; set; } // Asegúrate de incluir esto

    }
}
