

using Microsoft.EntityFrameworkCore;

namespace Restaurant.Infraestructure.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions dbContext) : base(dbContext)
        {
        }
    }
}
