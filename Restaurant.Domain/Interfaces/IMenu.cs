
namespace Restaurant.Domain.Interfaces
{
    public interface IMenu
    {
        //esto debe recibir una entidad llamada plato, pendiente por hacer
        Task AddPlato();
        Task RemovePlato();
        Task CreatePlato();
    }
}
