
using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Extentions;
using Restaurant.Infraestructure.Interfaces;
using Restaurant.Infraestructure.Models;


namespace Restaurante.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IRepository<Menu> _repository;

        public MenuController(IRepository<Menu> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuModel>>> GetMenus()
        {
            var menus = await _repository.GetAll();
            return Ok(menus.ToModels());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuModel>> GetMenu(int id)
        {
            var menu = await _repository.GetById(id);
            if (menu == null)
            {
                return NotFound();
            }
            return Ok(menu.ToModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenu(MenuModel menuModel)
        {
            var menu = menuModel.ToEntity();
            await _repository.Add(menu);
            return CreatedAtAction(nameof(GetMenu), new { id = menu.IdPlato }, menuModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenu(int id, MenuModel menuModel)
        {
            if (id != menuModel.IdPlato)
            {
                return BadRequest();
            }

            var menu = menuModel.ToEntity();
            await _repository.Update(menu);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            await _repository.Delete(id);
            return NoContent();
        }
    }
}
