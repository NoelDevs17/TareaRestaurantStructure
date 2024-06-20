

using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_;
using Restaurant.Infraestructure.Models;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions
{
    public static class MenuExtensions
    {
        public static MenuModel ToModel(this Menu menu)
        {
            return new MenuModel
            {
                IdPlato = menu.IdPlato,
                Nombre = menu.Nombre,
                Descripcion = menu.Descripcion,
                Precio = (decimal)menu.Precio,
                Categoria = menu.Categoria
            };
        }

        public static Menu ToEntity(this MenuModel menuModel)
        {
            return new Menu
            {
                IdPlato = menuModel.IdPlato,
                Nombre = menuModel.Nombre,
                Descripcion = menuModel.Descripcion,
                Precio = menuModel.Precio,
                Categoria = menuModel.Categoria
            };
        }

        public static IEnumerable<MenuModel> ToModels(this IEnumerable<Menu> menus)
        {
            return menus.Select(e => e.ToModel());
        }

    }
}
