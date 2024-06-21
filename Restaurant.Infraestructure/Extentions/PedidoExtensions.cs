using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class PedidoExtensions
    {
        public static PedidoModel ToModel(this Pedido pedido)
        {
            return new PedidoModel
            {
                IdPedido = pedido.IdPedido,
                IdCliente = pedido.IdCliente,
                IdMesa = pedido.IdMesa,
                Fecha = pedido.Fecha,
                Total = (decimal)pedido.Total
            };
        }

        public static Pedido ToEntity(this PedidoModel pedidoModel)
        {
            return new Pedido
            {
                IdPedido = pedidoModel.IdPedido,
                IdCliente = pedidoModel.IdCliente,
                IdMesa = pedidoModel.IdMesa,
                Fecha = pedidoModel.Fecha,
                Total = pedidoModel.Total
            };
        }

        public static IEnumerable<PedidoModel> ToModels(this IEnumerable<Pedido> pedidos)
        {
            return pedidos.Select(e => e.ToModel());
        }


    }
}
