

namespace Restaurant.Domain.Entities
{
    public class DetallePedido
    {
        public int IdDetallePedido { get; set; }
        public int IdPedido { get; set; }
        public int IdPlato { get; set; }
        public int? Cantidad { get; set; }
        public decimal? Subtotal { get; set; }

        public Pedido Pedido { get; set; } // Propiedad de navegacion a Pedido
        public Menu Menu { get; set; } // Propiedad de navegacion a Menu
    }
}
