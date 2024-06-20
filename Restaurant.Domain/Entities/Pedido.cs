
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

    }
}
