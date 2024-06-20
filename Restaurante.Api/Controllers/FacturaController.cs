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
    public class FacturaController : ControllerBase
    {
        private readonly IRepository<Factura> _repository;

        public FacturaController(IRepository<Factura> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaModel>>> GetFacturas()
        {
            var facturas = await _repository.GetAll();
            return Ok(facturas.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaModel>> GetFactura(int id)
        {
            var factura = await _repository.GetById(id);
            if (factura == null)
            {
                return NotFound();
            }
            return Ok(factura.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateFactura(FacturaModel facturaModel)
        {
            var factura = facturaModel.ToEntity();
            await _repository.Add(factura);
            return CreatedAtAction(nameof(GetFactura), new { id = factura.IdFactura }, facturaModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFactura(int id, FacturaModel facturaModel)
        {
            if (id != facturaModel.IdFactura)
            {
                return BadRequest();
            }

            var factura = facturaModel.ToEntity();
            await _repository.Update(factura);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactura(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
