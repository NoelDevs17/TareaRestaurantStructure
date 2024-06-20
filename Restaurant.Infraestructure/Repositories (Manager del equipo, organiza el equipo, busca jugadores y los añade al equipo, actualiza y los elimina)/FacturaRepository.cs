

using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;

namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
    public class FacturaRepository : IRepository<Factura>
    {
        private readonly MyDbContext _context;

        public FacturaRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Factura>> GetAll()
        {
            return await _context.Facturas.ToListAsync();
        }

        public async Task<Factura> GetById(int id)
        {
            return await _context.Facturas.FindAsync(id);
        }

        public async Task Add(Factura entity)
        {
            _context.Facturas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Factura entity)
        {
            _context.Facturas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var facturas = await _context.Facturas.FindAsync(id);
            if (facturas != null)
            {
                _context.Facturas.Remove(facturas);
                await _context.SaveChangesAsync();
            }
        }
    }
}
