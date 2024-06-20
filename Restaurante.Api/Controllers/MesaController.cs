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
    public class MesaController : ControllerBase
    {
        private readonly IRepository<Mesa> _repository;

        public MesaController(IRepository<Mesa> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesaModel>>> GetMesas()
        {
            var mesas = await _repository.GetAll();
            return Ok(mesas.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MesaModel>> GetMesa(int id)
        {
            var mesa = await _repository.GetById(id);
            if (mesa == null)
            {
                return NotFound();
            }
            return Ok(mesa.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateMesa(MesaModel mesaModel)
        {
            var mesa = mesaModel.ToEntity();
            await _repository.Add(mesa);
            return CreatedAtAction(nameof(GetMesa), new { id = mesa.IdMesa }, mesaModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMesa(int id, MesaModel mesaModel)
        {
            if (id != mesaModel.IdMesa)
            {
                return BadRequest();
            }

            var mesa = mesaModel.ToEntity();
            await _repository.Update(mesa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesa(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
