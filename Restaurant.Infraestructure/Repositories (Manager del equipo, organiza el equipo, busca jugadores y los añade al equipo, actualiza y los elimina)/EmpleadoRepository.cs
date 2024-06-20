

using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;

namespace Restaurant.Infraestructure.Repositories__Manager_del_equipo__organiza_el_equipo__busca_jugadores_y_los_añade_al_equipo__actualiza_y_los_elimina_
{
    public class EmpleadoRepository : IRepository<Empleado>
    {
        private readonly MyDbContext _context;

        public EmpleadoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAll()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado> GetById(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task Add(Empleado entity)
        {
            _context.Empleados.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Empleado entity)
        {
            _context.Empleados.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
