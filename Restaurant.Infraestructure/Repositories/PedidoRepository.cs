using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;


namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
    public class PedidoRepository : IRepository<Pedido>
    {
        private readonly MyDbContext _context;

        public PedidoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pedido>> GetAll()
        {
            return await _context.Pedidos
                       .Include(p => p.Cliente)
                       .Include(p => p.Mesa)
                       .ToListAsync();
        }

        public async Task<Pedido> GetById(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task Add(Pedido entity)
        {
            _context.Pedidos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Pedido entity)
        {
            var existingPedido = await _context.Pedidos
        .Include(p => p.Cliente)
        .Include(p => p.Mesa)
        .FirstOrDefaultAsync(p => p.IdPedido == entity.IdPedido);

            if (existingPedido != null)
            {
                _context.Entry(existingPedido).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
