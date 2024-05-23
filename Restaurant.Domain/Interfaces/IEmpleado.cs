
using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces
{
    public interface IEmpleado
    {
        Task GetById(int id);
        Task GetAll(List<Empleado> empleados);
        Task Create(Empleado empleado);
        Task Delete(int id);
        Task Update(Empleado empleado);
    }
}
