using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> _repository;

        public ClienteController(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteModel>>> GetClientes()
        {
            var clientes = await _repository.GetAll();
            return Ok(clientes.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> GetCliente(int id)
        {
            var cliente = await _repository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteModel clienteModel)
        {
            var cliente = clienteModel.ToEntity();
            await _repository.Add(cliente);
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, clienteModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return BadRequest();
            }

            var cliente = clienteModel.ToEntity();
            await _repository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
