

using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IRepository<Pedido> _repository;

        public PedidoService(IRepository<Pedido> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PedidoModel>> GetPedidosAsync()
        {
            var pedidos = await _repository.GetAll();
            return pedidos.Select(p => new PedidoModel
            {
                IdPedido = p.IdPedido,
                IdCliente = p.IdCliente,
                ClienteNombre = p.Cliente?.Nombre,
                IdMesa = p.IdMesa,
                MesaCapacidad = p.Mesa?.Capacidad,
                Fecha = p.Fecha,
                Total = p.Total ?? 0M // Convertir explicitamente a decimal
            });
        }

        public async Task<PedidoModel> GetPedidoByIdAsync(int id)
        {
            var pedido = await _repository.GetById(id);
            if (pedido == null)
            {
                return null;
            }
            return new PedidoModel
            {
                IdPedido = pedido.IdPedido,
                IdCliente = pedido.IdCliente,
                ClienteNombre = pedido.Cliente?.Nombre,
                IdMesa = pedido.IdMesa,
                MesaCapacidad = pedido.Mesa?.Capacidad,
                Fecha = pedido.Fecha,
                Total = pedido.Total ?? 0M // Convertir explicitamente a decimal
            };
        }
    }
}
