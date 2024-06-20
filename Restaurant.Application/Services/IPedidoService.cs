using Restaurant.Infraestructure.Models__Tarjeta_de_jugadores__muestra_informacion_importante_de_cada_jugador_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoModel>> GetPedidosAsync();
        Task<PedidoModel> GetPedidoByIdAsync(int id);
    }
}
