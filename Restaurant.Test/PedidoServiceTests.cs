

using Moq;
using Restaurant.Application.Services;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Interfaces;

namespace Restaurant.Test
{
    public class PedidoServiceTests
    {
        private readonly Mock<IRepository<Pedido>> _pedidoRepositoryMock;
        private readonly PedidoService _pedidoService;

        public PedidoServiceTests()
        {
            _pedidoRepositoryMock = new Mock<IRepository<Pedido>>();
            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object);
        }


        [Fact]
        public async Task GetPedidosAsync_ReturnsPedidos()
        {
            // Arrange
            var pedidos = new List<Pedido>
        {
            new Pedido { IdPedido = 1, IdCliente = 1, Fecha = DateTime.Now, Total = 100 },
            new Pedido { IdPedido = 2, IdCliente = 2, Fecha = DateTime.Now, Total = 200 }
        };
            _pedidoRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(pedidos);

            // Act
            var result = await _pedidoService.GetPedidosAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal(100, result.First().Total);
        }
    }
}
