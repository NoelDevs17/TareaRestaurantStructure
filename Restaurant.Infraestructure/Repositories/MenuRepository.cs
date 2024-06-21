

using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Context;
using Restaurant.Infraestructure.Interfaces;

namespace Restaurant.Infraestructure.Repositories
{
    public class MenuRepository : IRepository<Menu>
    {
        private readonly MyDbContext _context;

        public MenuRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu> GetById(int id)
        {
            return await _context.Menus.FindAsync(id);
        }

        public async Task Add(Menu entity)
        {
            _context.Menus.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Menu entity)
        {
            _context.Menus.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu != null)
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }
        }
    }
}
