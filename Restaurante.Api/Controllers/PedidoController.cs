using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IRepository<Pedido> _repository;

        public PedidoController(IRepository<Pedido> repository)
        {
            _repository = repository;
        }

        [HttpGet("GetPedidos")]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> GetPedidos()
        {
            var pedidos = await _repository.GetAll();
            var pedidoModels = pedidos.Select(p => new PedidoModel
            {
                IdPedido = p.IdPedido,
                IdCliente = p.IdCliente,
                ClienteNombre = p.Cliente?.Nombre,
                IdMesa = p.IdMesa,
                MesaCapacidad = p.Mesa?.Capacidad,
                Fecha = p.Fecha,
                Total = p.Total
            });
            return Ok(pedidoModels);
        }

        [HttpGet("GetPedidosById/{id}")]
        public async Task<ActionResult<PedidoModel>> GetPedido(int id)
        {
            var pedido = await _repository.GetById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            var pedidoModel = new PedidoModel
            {
                IdPedido = pedido.IdPedido,
                IdCliente = pedido.IdCliente,
                ClienteNombre = pedido.Cliente?.Nombre,
                IdMesa = pedido.IdMesa,
                MesaCapacidad = pedido.Mesa?.Capacidad,
                Fecha = pedido.Fecha,
                Total = pedido.Total
            };
            return Ok(pedidoModel);
        }

        [HttpPost("CreatePedido")]
        public async Task<ActionResult> CreatePedido(PedidoModel pedidoModel)
        {
            var pedido = pedidoModel.ToEntity();
            await _repository.Add(pedido);
            return CreatedAtAction(nameof(GetPedido), new { id = pedido.IdPedido }, pedidoModel);
        }

        [HttpPut("UpdatePedido/{id}")]
        public async Task<IActionResult> UpdatePedido(int id, PedidoModel pedidoModel)
        {
            if (id != pedidoModel.IdPedido)
            {
                return BadRequest();
            }

            var pedido = pedidoModel.ToEntity();
            await _repository.Update(pedido);
            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
