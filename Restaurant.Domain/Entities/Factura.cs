
namespace Restaurant.Domain.Entities
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public int? IdPedido { get; set; }
        public decimal? Total { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
