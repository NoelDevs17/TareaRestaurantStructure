using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;


namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
    public class MesaRepository : IRepository<Mesa>
    {
        private readonly MyDbContext _context;

        public MesaRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesa>> GetAll()
        {
            return await _context.Mesas.ToListAsync();
        }

        public async Task<Mesa> GetById(int id)
        {
            return await _context.Mesas.FindAsync(id);
        }

        public async Task Add(Mesa entity)
        {
            _context.Mesas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Mesa entity)
        {
            _context.Mesas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var mesas = await _context.Mesas.FindAsync(id);
            if (mesas != null)
            {
                _context.Mesas.Remove(mesas);
                await _context.SaveChangesAsync();
            }
        }
    }
}
