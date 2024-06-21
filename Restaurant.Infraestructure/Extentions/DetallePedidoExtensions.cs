using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class DetallePedidoExtensions
    {
        public static DetallePedidoModel ToModel(this DetallePedido detallePedido)
        {
            return new DetallePedidoModel
            {
                IdDetallePedido = detallePedido.IdDetallePedido,
                IdPedido = detallePedido.IdPedido,
                IdPlato = detallePedido.IdPlato,
                Cantidad = detallePedido.Cantidad ?? default,
                Subtotal = detallePedido.Subtotal ?? default
            };
        }

        public static DetallePedido ToEntity(this DetallePedidoModel detallePedidoModel)
        {
            return new DetallePedido
            {
                IdDetallePedido = detallePedidoModel.IdDetallePedido,
                IdPedido = detallePedidoModel.IdPedido,
                IdPlato = detallePedidoModel.IdPlato,
                Cantidad = detallePedidoModel.Cantidad,
                Subtotal = detallePedidoModel.Subtotal
            };
        }

        public static IEnumerable<DetallePedidoModel> ToModels(this IEnumerable<DetallePedido> detallePedidos)
        {
            return detallePedidos.Select(e => e.ToModel());
        }
    }
}
