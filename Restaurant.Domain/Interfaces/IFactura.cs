

using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces
{
    public interface IFactura
    {
        Task Update(string id);
        Task GetById(string id);
        Task GetAll(List<Pedido> pedidos);
        Task Create();
        Task Save(Factura factura );
        Task SaveList(List<Factura> facturaList);
    }
}
