

using Restaurant.Domain.Interfaces;
using Restaurant.Infraestructure.Context;

namespace Restaurant.Infraestructure.Repositories
{
    public class MenuRepository : IMenu
    {
        private readonly MyDbContext myDbContext;
        public MenuRepository(MyDbContext dbContext)
        {
            this.myDbContext = dbContext;
        }

        public Task AddPlato()
        {
            throw new NotImplementedException();
        }

        public Task CreatePlato()
        {
            throw new NotImplementedException();
        }

        public Task RemovePlato()
        {
            throw new NotImplementedException();
        }
    }
}
