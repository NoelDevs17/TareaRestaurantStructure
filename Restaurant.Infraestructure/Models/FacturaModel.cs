

namespace Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }
        public int IdPedido { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
    }
}
