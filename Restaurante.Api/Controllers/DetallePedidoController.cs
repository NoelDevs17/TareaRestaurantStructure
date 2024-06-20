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
    public class DetallePedidoController : ControllerBase
    {
        private readonly IRepository<DetallePedido> _repository;

        public DetallePedidoController(IRepository<DetallePedido> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedidoModel>>> GetDetallePedidos()
        {
            var detallePedidos = await _repository.GetAll();
            return Ok(detallePedidos.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedidoModel>> GetDetallePedido(int id)
        {
            var detallePedido = await _repository.GetById(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            return Ok(detallePedido.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateDetallePedido(DetallePedidoModel detallePedidoModel)
        {
            var detallePedido = detallePedidoModel.ToEntity();
            await _repository.Add(detallePedido);
            return CreatedAtAction(nameof(GetDetallePedido), new { id = detallePedido.IdPedido }, detallePedidoModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDetallePedido(int id, DetallePedidoModel detallePedidoModel)
        {
            if (id != detallePedidoModel.IdPedido)
            {
                return BadRequest();
            }

            var detallePedido = detallePedidoModel.ToEntity();
            await _repository.Update(detallePedido);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
