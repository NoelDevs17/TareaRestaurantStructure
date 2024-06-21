using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entities;
using Restaurant.Application.Services;
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
        private readonly IPedidoService _pedidoService;

        public PedidoController(IRepository<Pedido> repository, IPedidoService pedidoService)
        {
            _repository = repository;
            _pedidoService = pedidoService;
         
        }

        [HttpGet("GetPedidos")]
        public async Task<IActionResult> GetPedidos()
        {
            var pedidos = await _pedidoService.GetPedidosAsync();
            return Ok(pedidos);
        }


        [HttpGet("GetPedidosById/{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidoService.GetPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost("CreatePedido")]
        public async Task<IActionResult> CreatePedido([FromBody] PedidoModel pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPedido = await _pedidoService.CreatePedidoAsync(pedido);
            return CreatedAtAction(nameof(GetPedidoById), new { id = createdPedido.IdPedido }, createdPedido);
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
