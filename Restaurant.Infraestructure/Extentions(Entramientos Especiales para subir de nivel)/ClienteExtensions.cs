

using Restaurant.Domain.Entities;
using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;

namespace Restaurant.Infraestructure.Extentions_Entramientos_Especiales_para_subir_de_nivel_
{
    public static class ClienteExtensions
    {
        public static ClienteModel ToModel(this Cliente cliente)
        {
            return new ClienteModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                CreationDate = cliente.CreationDate
            };
        }

        public static Cliente ToEntity(this ClienteModel clienteModel)
        {
            return new Cliente
            {
                Id = clienteModel.Id,
                Nombre = clienteModel.Nombre,
                Telefono = clienteModel.Telefono,
                Email = clienteModel.Email,
                CreationDate = clienteModel.CreationDate
            };
        }

        public static IEnumerable<ClienteModel> ToModels(this IEnumerable<Cliente> clientes)
        {
            return clientes.Select(e => e.ToModel());
        }
    }
}
