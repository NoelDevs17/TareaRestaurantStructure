using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class EmpleadoExtensions
    {
        public static EmpleadoModel ToModel(this Empleado empleado)
        {
            return new EmpleadoModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo,
                CreationDate = empleado.CreationDate
            };
        }

        public static Empleado ToEntity(this EmpleadoModel empleadoModel)
        {
            return new Empleado
            {
                Id = empleadoModel.Id,
                Nombre = empleadoModel.Nombre,
                Cargo = empleadoModel.Cargo,
                CreationDate = empleadoModel.CreationDate
            };
        }

        public static IEnumerable<EmpleadoModel> ToModels(this IEnumerable<Empleado> empleados)
        {
            return empleados.Select(e => e.ToModel());
        }
    }
}
