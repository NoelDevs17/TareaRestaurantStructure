

using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class FacturaExtensions
    {
        public static FacturaModel ToModel(this Factura factura)
        {
            return new FacturaModel
            {
                IdFactura = factura.IdFactura,
                IdPedido = factura.IdPedido ?? default,
                Total = factura.Total ?? default,
                Fecha = factura.Fecha
            };
        }

        public static Factura ToEntity(this FacturaModel facturaModel)
        {
            return new Factura
            {
                IdFactura = facturaModel.IdFactura,
                IdPedido = facturaModel.IdPedido,
                Total = facturaModel.Total,
                Fecha = facturaModel.Fecha
            };
        }

        public static IEnumerable<FacturaModel> ToModels(this IEnumerable<Factura> facturas)
        {
            return facturas.Select(e => e.ToModel());
        }
    }
}
