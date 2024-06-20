using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IRepository<Empleado> _repository;

        public EmpleadoController(IRepository<Empleado> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoModel>>> GetEmpleados()
        {
            var empleados = await _repository.GetAll();
            return Ok(empleados.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoModel>> GetEmpleado(int id)
        {
            var empleado = await _repository.GetById(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return Ok(empleado.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmpleado(EmpleadoModel empleadoModel)
        {
            var empleado = empleadoModel.ToEntity();
            await _repository.Add(empleado);
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleadoModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, EmpleadoModel empleadoModel)
        {
            if (id != empleadoModel.Id)
            {
                return BadRequest();
            }

            var empleado = empleadoModel.ToEntity();
            await _repository.Update(empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
