using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;


namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly MyDbContext _context;

        public ClienteRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Add(Cliente entity)
        {
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente entity)
        {
            _context.Clientes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
