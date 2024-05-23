
namespace Restaurant.Domain.Interfaces
{
    public interface IMenu
    {
        Task AddPlato();
        Task RemovePlato();
        Task CreatePlato();
    }
}
