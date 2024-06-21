using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;

namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
     public class DetallePedidoRepository : IRepository<DetallePedido>
    {
        private readonly MyDbContext _context;

        public DetallePedidoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DetallePedido>> GetAll()
        {
            return await _context.DetallesPedido.ToListAsync();
        }

        public async Task<DetallePedido> GetById(int id)
        {
            return await _context.DetallesPedido.FindAsync(id);
        }

        public async Task Add(DetallePedido entity)
        {
            _context.DetallesPedido.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(DetallePedido entity)
        {
            _context.DetallesPedido.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var detallesPedido = await _context.DetallesPedido.FindAsync(id);
            if (detallesPedido != null)
            {
                _context.DetallesPedido.Remove(detallesPedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
