


using Microsoft.AspNetCore.Mvc;
using Moq;
using Restaurant.Application.Services;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;
using Restaurante.Api.Controllers;

namespace Restaurant.Test
{
    public class PedidoControllerTests
    {
        private readonly Mock<IRepository<Pedido>> _pedidoRepositoryMock;
        private readonly Mock<IPedidoService> _pedidoServiceMock;
        private readonly PedidoController _pedidoController;
        

        public PedidoControllerTests()
        {
            _pedidoRepositoryMock = new Mock<IRepository<Pedido>>();
            _pedidoServiceMock = new Mock<IPedidoService>();
            _pedidoController = new PedidoController(_pedidoRepositoryMock.Object, _pedidoServiceMock.Object);
        }

        [Fact]
        public async Task GetPedidos_ReturnsPedidos()
        {
            // Arrange
            var pedidos = new List<PedidoModel>
    {
        new PedidoModel { IdPedido = 1, ClienteNombre = "Juan" }
    };

            _pedidoServiceMock.Setup(service => service.GetPedidosAsync())
                              .ReturnsAsync(pedidos);

            // Act
            var result = await _pedidoController.GetPedidos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PedidoModel>>(okResult.Value);
            Assert.Equal(pedidos.Count, returnValue.Count);

        }

        [Fact]
        public async Task GetPedidoById_ReturnsPedido_WhenPedidoExists()
        {
            // Arrange
            var pedido = new PedidoModel { IdPedido = 1, ClienteNombre = "Juan" };
            _pedidoServiceMock.Setup(service => service.GetPedidoByIdAsync(1))
                              .ReturnsAsync(pedido);

            // Act
            var result = await _pedidoController.GetPedidoById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PedidoModel>(okResult.Value);
            Assert.Equal(pedido.IdPedido, returnValue.IdPedido);
        }

        [Fact]
        public async Task GetPedidoById_ReturnsNotFound_WhenPedidoDoesNotExist()
        {
            // Arrange
            _pedidoServiceMock.Setup(service => service.GetPedidoByIdAsync(1))
                              .ReturnsAsync((PedidoModel)null);

            // Act
            var result = await _pedidoController.GetPedidoById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreatePedido_ReturnsCreatedPedido()
        {
            // Arrange
            var pedido = new PedidoModel { IdPedido = 1, ClienteNombre = "Juan" };
            _pedidoServiceMock.Setup(service => service.CreatePedidoAsync(pedido))
                              .ReturnsAsync(pedido);

            // Act
            var result = await _pedidoController.CreatePedido(pedido);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<PedidoModel>(createdAtActionResult.Value);
            Assert.Equal(pedido.IdPedido, returnValue.IdPedido);
        }


    }


}
