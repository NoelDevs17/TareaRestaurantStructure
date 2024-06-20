

using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class MesaExtensions
    {
        public static MesaModel ToModel(this Mesa mesa)
        {
            return new MesaModel
            {
                IdMesa = mesa.IdMesa,
                Capacidad = int.TryParse(mesa.Capacidad, out var capacidad) ? capacidad : default,
                Estado = mesa.Estado
            };
        }

        public static Mesa ToEntity(this MesaModel mesaModel)
        {
            return new Mesa
            {
                IdMesa = mesaModel.IdMesa,
                Capacidad = mesaModel.Capacidad.ToString(),
                Estado = mesaModel.Estado
            };
        }

        public static IEnumerable<MesaModel> ToModels(this IEnumerable<Mesa> mesas)
        {
            return mesas.Select(e => e.ToModel());
        }
    }

}
