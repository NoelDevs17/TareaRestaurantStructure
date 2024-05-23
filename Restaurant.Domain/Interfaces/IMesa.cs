
namespace Restaurant.Domain.Interfaces
{
    public interface IMesa
    {
        Task GetAll();
        Task Create();
        Task Delete(int id);
    }
}
