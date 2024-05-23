

using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces
{
    public interface IPedido
    {
        Task Create(Pedido pedido);
        Task Cancelar(int id);
        Task GetPedido(int id);
    }
}
